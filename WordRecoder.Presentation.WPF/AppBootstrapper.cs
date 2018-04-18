﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using Autofac;
using AutoMapper;
using Caliburn.Micro;
using Domain.Core.Dependency;
using Domain.Core.IRepository;
using WordRecoder.Infrastructure.Migration;
using WordRecoder.Infrastructure.Repository;
using WordRecoder.Presentation.WPF.ViewModels.Main;

namespace WordRecoder.Presentation.WPF
{
    public class AppBootstrapper : BootstrapperBase
    {
        private IContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();
            //注册实例
            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            builder.RegisterType<DbConnectionProvider>().As<IDbConnectionProvider>();

            #region 注册View ViewModel
            builder.RegisterType<ShellViewModel>().AsSelf();
            #endregion

            #region 通过程序集注册服务
            //通过程序集注册应用服务和仓储
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            List<Assembly> list = new List<Assembly>();
            foreach (var file in files)
            {
                Assembly assembly = Assembly.LoadFile(file);

                if (assembly.FullName.Contains("Application")
                    || assembly.FullName.Contains("Infrastructure")
                    || assembly.FullName.Contains("Domain"))
                    list.Add(assembly);
            }
            builder.RegisterAssemblyTypes(list.ToArray()).AsImplementedInterfaces()
                .As<ITransientDependency>();//只注册继承自ITransientDependency接口的实例
            builder.RegisterAssemblyTypes(list.ToArray()).AsImplementedInterfaces()
                .As<ISingletonDependency>().SingleInstance();//注册为单例
            #endregion

            //注册应用程序服务
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces()
             .As<ITransientDependency>();

            this.container = builder.Build();

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

        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //执行迁移
            var repository = container.Resolve<IMigrationRepository>();
            new MigrationSerivce(repository).ExecuteMigration();

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            object instance = null;

            if (!string.IsNullOrWhiteSpace(key))
                container.TryResolveNamed(key, service, out instance);
            else
                instance = container.Resolve(service);

            return instance;
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
        }

        protected override void BuildUp(object instance)
        {
            container.InjectProperties(instance);
        }
    }
}
