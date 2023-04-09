using Books.Plugin.ModuleA.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Books.Plugin.ModuleA.Views
{
    /// <summary>
    /// ViewC.xaml 的交互逻辑
    /// </summary>
    public partial class ViewC : UserControl
    {
        /// <summary>
        /// 消息订阅的事件收集器
        /// </summary>
        private readonly IEventAggregator aggregator;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="aggregator">事件收集器</param>
        public ViewC(IEventAggregator aggregator)
        {
            InitializeComponent();
 
            this.aggregator = aggregator;
            // 消息订阅
            this.aggregator.GetEvent<MessageEvent>().Subscribe(SubMessage);
        }

        private void SubMessage(string obj)
        {
            // 接受消息内容
            MessageBox.Show($"Received Message: {obj}");

            // 取消消息订阅
            this.aggregator.GetEvent<MessageEvent>().Unsubscribe(SubMessage);
        }
    }
}
