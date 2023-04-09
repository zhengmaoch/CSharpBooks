using Books.Plugin.ModuleA.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Plugin.ModuleA.ViewModels
{
    /// <summary>
    /// 对话框的ViewModels,处理对话框的业务逻辑
    /// </summary>
    public class ViewCViewModels : IDialogAware
    {
        /// <summary>
        /// 定义发布订阅消息的收集器，通过构造函数进行注入
        /// </summary>
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 取消命令
        /// </summary>
        public DelegateCommand CancelCommand { get; set; }

        /// <summary>
        /// 确定命令
        /// </summary>
        public DelegateCommand OKCommand { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="aggregator">消息发布订阅的事件收集器</param>
        public ViewCViewModels(IEventAggregator aggregator) {
            // 取消命令委托Cancal方法
            CancelCommand = new DelegateCommand(Cancel);
            // 确定命令委托OK方法
            OKCommand = new DelegateCommand(OK);
            this.aggregator = aggregator;
            
        }

        /// <summary>
        /// 确定的业务逻辑
        /// </summary>
        private void OK()
        {
            // 向 MessageEvent 发布一个string类型的的消息 Hello ViewC
            aggregator.GetEvent<MessageEvent>().Publish("Hello ViewC");

            OnDialogClosed();
        }

        /// <summary>
        /// 取消的业务逻辑
        /// </summary>
        private void Cancel()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public string Title { get; set; }

        /// <summary>
        /// 带参数的对话框返回
        /// </summary>
        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            var keys = new DialogParameters
            {
                { "Value", "Hello Dialog" }
            };
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        /// <summary>
        /// 打开对话框，接收IDialogParameters参数
        /// </summary>
        /// <param name="parameters">传递参数集合</param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 获取参数更新对话框数据
            Title = parameters.GetValue<string>("Title");
        }
    }
}
