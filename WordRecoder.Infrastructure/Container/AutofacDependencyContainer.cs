using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace WordRecoder.Infrastructure.Container
{
    public class AutofacDependencyContainer : IDependencyContainer
    {
        private static ContainerBuilder builder = new ContainerBuilder();
        private static IContainer container;

        public void Build()
        {           
            container = builder.Build();
        }

        
        public T GetSerivces<T>()
        {
            return container.Resolve<T>();
        }

        public void RegisterType<Implementer, TSerives>()
        {
            builder.RegisterType<Implementer>().As<TSerives>();
        }

        public void RegisterInstance<Implementer, TSerives>()
        {
            builder.RegisterType<Implementer>().SingleInstance().As<TSerives>();
        }
        
    }
}
