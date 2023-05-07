using Books.Wpf.Views;
using Example;
using MaterialDesignThemes.Wpf;
using Microsoft.Extensions.DependencyInjection;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Books.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication // 通过继承PrismApplication引入Prism框架
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
        }

        private void ConfigureServices(IServiceCollection services)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            App.ServiceProvider = serviceProvider; //便于全局使用;

            //services.AddSingleton<ITextService>(provider => new TextService("Hi WPF .NET Core 3.0"));
            services.AddSingleton<MainView>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainView>();
        }

        /// <summary>
        /// 容器对象类型注册
        /// </summary>
        /// <param name="containerRegistry">注册器</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.ConfigurationServices();
        }

        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ModuleAProfile>();
        //    moduleCatalog.AddModule<ModuleBProfile>();
        //    base.ConfigureModuleCatalog(moduleCatalog);
        //}

        /// <summary>
        /// 通过文件目录路径完成模块注册
        /// </summary>
        /// <returns></returns>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new DirectoryModuleCatalog(){ ModulePath = @".\Modules" };
        }
    }
}
