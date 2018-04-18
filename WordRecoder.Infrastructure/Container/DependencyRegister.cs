using Domain.Core.IRepository;
using WordRecoder.Domain.IRepositories;
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
            dependencyContainer.RegisterType<WordRootRepository, IWordRootRepository>();
            dependencyContainer.RegisterType<DbConnectionProvider, IDbConnectionProvider>();
        }


    }
}
