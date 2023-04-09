using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Books.Plugin.ModuleA.ViewModels
{
    public class ViewAViewModels : BindableBase, IConfirmNavigationRequest
    {
        public ViewAViewModels()
        { 

        }

        /// <summary>
        /// 申明私有变量用于界面绑定
        /// </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 每次重新导航的时候，是否重用原来的实例
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <returns></returns>
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// 导航请求拦截
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        /// <summary>
        /// 接收导航参数
        /// </summary>
        /// <param name="navigationContext"></param>
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if(navigationContext.Parameters.ContainsKey("Title"))
                Title = navigationContext.Parameters.GetValue<string>("Title");
        }

        /// <summary>
        /// 导航请求确认
        /// </summary>
        /// <param name="navigationContext"></param>
        /// <param name="continuationCallback"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            bool result = true;
            if (MessageBox.Show("Conform Navigation?", "Information", MessageBoxButton.YesNo) == MessageBoxResult.No)
                result = false;

            // 通过委托将结果返回给Navigation做进一步处理
            continuationCallback(result);
        }
    }
}
