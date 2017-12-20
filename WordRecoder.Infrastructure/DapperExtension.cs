using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WordRecoder.Domain.Entities.DbAttributes;
using System.Collections;

namespace WordRecoder.Infrastructure
{
    public static class DapperExtension
    {
        public static string GetInsertSql(this object data)
        {
            var tableName = GetTableName(data);
            var columns = GetColumns(data);

            return string.Format("insert into {0} ({1})Values({2});", tableName, string.Join(",", columns), string.Join(",", columns.Select(p => "@" + p)));

        }

        public static string GetUpdateSql(this object data)
        {
            var tableName = GetTableName(data);
            var columns = GetColumns(data);

            string idName = string.Empty;
            var properties = data.GetType().GetProperties();
            foreach (var property in properties)
            {
                var IdAttribute = property.GetCustomAttributes(true).Where(p => p is IdAttribute).ToList();
                if (IdAttribute != null && IdAttribute.Count > 0)
                {
                    idName = property.Name;
                    break;
                }
            }
            string condition = string.Format(" where {0}=@{0}", idName);
            return string.Format("update {0} set {1} {2};", tableName, string.Join(",", columns.Select(p => p + "=@" + p)), condition);
        }

        private static List<string> GetColumns(object data)
        {
            var properties = data.GetType().GetProperties();

            List<string> columns = new List<string>();
            foreach (var property in properties)
            {
                var dbAttribute = property.GetCustomAttributes(true).Where(p => p is DbAttribute).ToList();

                if (dbAttribute.Exists(p => p is IdAttribute || p is IgnoreAttribute))
                    continue;

                Type type = property.GetType();
                var value = property.GetValue(data, null);
                if (value == null)
                    continue;
                //空值判断
                if (type == typeof(string))
                {
                    if (string.IsNullOrWhiteSpace(value.ToString())) continue;
                }
                else if (type == typeof(IList))
                {
                    var list = (IList)value;
                    if (list.Count <= 0) continue;
                }

                string columnName = string.Empty;
                var columnAttribute = dbAttribute.OfType<ColumnAttribute>().FirstOrDefault();
                if (columnAttribute != null)
                    columnName = columnAttribute.ColumnName;
                else
                    columnName = property.Name;

                columns.Add(columnName);
            }

            return columns;
        }

        private static string GetTableName(object data)
        {
            var dataType = data.GetType();
            var properties = dataType.GetProperties();

            string tableName = string.Empty;
            var tableAttribute = dataType.CustomAttributes.OfType<TableAttribute>().FirstOrDefault();
            if (tableAttribute != null)
                tableName = tableAttribute.TableName;
            else
                tableName = dataType.Name;

            return tableName;
        }
    }
}
