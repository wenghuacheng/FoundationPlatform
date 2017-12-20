using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Infrastructure.Migration
{
    public class MigrationAttribute : Attribute
    {
        public MigrationAttribute(long Version)
        {
            this.Version = Version;
        }


        public long Version { get; set; }
    }
}
