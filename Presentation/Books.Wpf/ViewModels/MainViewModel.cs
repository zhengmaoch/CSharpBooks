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
        /// <summary>
        /// 区域管理器
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// 导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        /// <summary>
        /// 打开模块
        /// </summary>
        public DelegateCommand<string> OpenCommand { get; private set; }

        // 上一步
        public DelegateCommand BackCommand { get; private set; }

        // 下一步
        public DelegateCommand ForwardCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            BackCommand = new DelegateCommand(Back);
            ForwardCommand = new DelegateCommand(Forward);
            this.regionManager = regionManager;
        }

        /// <summary>
        /// 导航至上一步
        /// </summary>
        private void Forward()
        {
            if (journal.CanGoForward)
                journal.GoForward();
        }

        /// <summary>
        /// 导航至下一步
        /// </summary>
        private void Back()
        {
            if(journal.CanGoBack)
                journal.GoBack();
        }

        //private object body;
        //public object Body { 
        //    get { return body; } 
        //    set { body = value; RaisePropertyChanged(); } 
        //}

        /// <summary>
        /// 打开模块
        /// </summary>
        /// <param name="obj"></param>
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
            regionManager.Regions["ContentRegion"].RequestNavigate(obj, callBack =>
            {
                // 通过导航回调设置导航日志
                if ((bool)callBack.Result)
                {
                    journal = callBack.Context.NavigationService.Journal;
                }
            }, keys);
        }
    }
}
