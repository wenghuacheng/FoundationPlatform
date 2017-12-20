using System;
using System.Collections.Generic;
using System.Text;
using WordRecoder.Application.ApplicationServices;
using WordRecoder.Application.IApplicationServices;
using WordRecoder.Infrastructure.Container;

namespace WordRecoder.Application
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
            this.dependencyContainer.RegisterType<RootSerivce,IRootSerivce>();
            this.dependencyContainer.RegisterType<WordService, IWordService>();
        }
    }
}
