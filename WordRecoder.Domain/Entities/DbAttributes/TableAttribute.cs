using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Domain.Entities.DbAttributes
{
    public class TableAttribute : DbAttribute
    {
        public TableAttribute(string tableName)
        {
            this.TableName = tableName;
        }

        public string TableName { get; set; }
    }
}
