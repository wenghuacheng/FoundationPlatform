using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.Entities.DbAttributes
{
    public class ColumnAttribute : DbAttribute
    {
        public ColumnAttribute(string ColumnName)
        {
            this.ColumnName = ColumnName;
        }

        public string ColumnName { get; set; }
    }
}
