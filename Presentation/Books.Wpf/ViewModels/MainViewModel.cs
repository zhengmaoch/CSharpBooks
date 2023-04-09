using Books.Wpf.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Wpf.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> OpenCommand { get; private set; }
        public MainViewModel(IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            this.regionManager = regionManager;
        }

        //private object body;
        //public object Body { 
        //    get { return body; } 
        //    set { body = value; RaisePropertyChanged(); } 
        //}

        private void Open(string obj)
        {
            //switch (obj)
            //{
            //    case "A": Body = new ViewA(); break;
            //    case "B": Body = new ViewB(); break;
            //    case "C": Body = new ViewC(); break;
            //}
            // 设置导航参数
            var keys = new NavigationParameters()
            {
                { "Title", "Hello!" }
            };

            // 通过IRegionManager接口获取当前全局定义的可用区域
            // 往这个区域动态设置内容
            // 设置内容的方式是通过依赖注入的形式
            regionManager.Regions["ContentRegion"].RequestNavigate(obj, keys);
        }
    }
}
