using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Plugin.ModuleA.Event
{
    /// <summary>
    /// 消息事件定义，消息内容为string类型的数据
    /// </summary>
    public class MessageEvent : PubSubEvent<string>
    {

    }

    /// <summary>
    /// 消息事件定义，消息内容为Test的对象
    /// </summary>
    public class TestEvent : PubSubEvent<Test>
    {

    }

    public class Test
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
