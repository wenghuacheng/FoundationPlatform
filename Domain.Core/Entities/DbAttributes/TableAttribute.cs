using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities.DbAttributes
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
