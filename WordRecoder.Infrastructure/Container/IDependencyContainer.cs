using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Infrastructure.Container
{
    public interface IDependencyContainer
    {
        void RegisterType<Implementer, Serives>();

        void RegisterInstance<Implementer, TSerives>();

        T GetSerivces<T>();

        void Build();
        
    }
}
