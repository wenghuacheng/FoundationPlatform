using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.IRepository
{
    public interface IMigrationRepository
    {
        void AddMigration(int version);

        long GetMaxVersion();
    }
}
