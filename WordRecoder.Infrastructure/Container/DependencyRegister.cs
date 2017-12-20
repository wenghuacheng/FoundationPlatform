using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using WordRecoder.Domain.IRepository;
using WordRecoder.Infrastructure.Repository;

namespace WordRecoder.Infrastructure.Container
{
    public class DependencyRegister
    {
        private IDependencyContainer dependencyContainer;

        public DependencyRegister(IDependencyContainer container)
        {
            this.dependencyContainer = container;
        }

        public void Register()
        {
            dependencyContainer.RegisterType<MigrationRepository, IMigrationRepository>();
            dependencyContainer.RegisterType<WordRepository, IWordRepository>();
            dependencyContainer.RegisterType<RootRepository, IRootRepository>();
            dependencyContainer.RegisterType<WordRootRepository, IWordRootRepository>();
            dependencyContainer.RegisterType<DbConnectionProvider, IDbConnectionProvider>();
        }


    }
}
