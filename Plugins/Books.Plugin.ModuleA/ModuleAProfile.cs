using Books.Plugin.ModuleA.ViewModels;
using Books.Plugin.ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Plugin.ModuleA
{
    public class ModuleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 容器中注册ViewA，及与之匹配的ViewAviewModel
            containerRegistry.RegisterForNavigation<ViewA, ViewAViewModels>();
            // 容器中注册对话框
            containerRegistry.RegisterDialog<ViewC, ViewCViewModels>();
        }
    }
}
