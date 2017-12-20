using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Domain.IRepository
{
    public interface IMigrationRepository
    {
        void AddMigration(int version);

        long GetMaxVersion();
    }
}
