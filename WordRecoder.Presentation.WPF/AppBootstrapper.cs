using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using WordRecoder.Presentation.WPF.ViewModels.Main;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using WordRecoder.Infrastructure.Container;
using WordRecoder.Domain.IRepository;
using WordRecoder.Infrastructure.Migration;
using AutoMapper;
using WordRecoder.Presentation.WPF.General.Interfaces;

namespace WordRecoder.Presentation.WPF
{
    public class AppBootstrapper : BootstrapperBase
    {
        private SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IDependencyContainer, AutofacDependencyContainer>();
            container.PerRequest<ShellViewModel>();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //注册实例
            var dependencyContainer = container.GetInstance<IDependencyContainer>();
            new WordRecoder.Infrastructure.Container.DependencyRegister(dependencyContainer).Register();
            new WordRecoder.Application.DependencyRegister(dependencyContainer).Register();

            dependencyContainer.RegisterInstance<PageManagerViewModel, IPageManager>();

            dependencyContainer.Build();

            //automapper
            Mapper.Initialize((config) =>
            {
                WordRecoder.Application.MapperCreator.GetProfile().ForEach(p =>
                {
                    config.AddProfile(p);
                });
                MapperCreator.GetProfile().ForEach(p =>
                {
                    config.AddProfile(p);
                });
            });

            //执行迁移
            var repository = dependencyContainer.GetSerivces<IMigrationRepository>();
            new MigrationSerivce(repository).ExecuteMigration();

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

    }
}
