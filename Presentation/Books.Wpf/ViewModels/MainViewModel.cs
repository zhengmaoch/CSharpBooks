using Books.Wpf.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
        /// 对话框管理器
        /// </summary>
        private readonly IDialogService dialogService;

        /// <summary>
        /// 区域导航日志
        /// </summary>
        private IRegionNavigationJournal journal;

        /// <summary>
        /// 打开模块
        /// </summary>
        public DelegateCommand<string> OpenModuleCommand { get; private set; }

        /// <summary>
        /// 打开对话框
        /// </summary>
        public DelegateCommand<string> OpenDialogCommand { get; private set; }

        // 上一步
        public DelegateCommand BackCommand { get; private set; }

        private string information = "information";
        public string Information { get { return information; } set { information = value; RaisePropertyChanged(); } }

        // 下一步
        public DelegateCommand ForwardCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            OpenModuleCommand = new DelegateCommand<string>(OpenModule);
            OpenDialogCommand = new DelegateCommand<string>(OpenDialog);
            BackCommand = new DelegateCommand(Back);
            ForwardCommand = new DelegateCommand(Forward);
            this.regionManager = regionManager;
            this.dialogService = dialogService;
        }

        private void OpenDialog(string obj)
        {
            var keys = new DialogParameters
            {
                { "Title", "Test Dialog" }
            };
            dialogService.ShowDialog(obj,keys, callback =>
            {
                if(callback.Result == ButtonResult.OK)
                {
                    Information = callback.Parameters.GetValue<string>("Value");
                }
            });
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
        private void OpenModule(string obj)
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
