using Domain.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.IRepository
{
    public interface IMigrationRepository : ITransientDependency
    {
        void AddMigration(int version);

        long GetMaxVersion();
    }
}
