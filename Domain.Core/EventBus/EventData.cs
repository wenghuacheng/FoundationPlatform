using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.EventBus
{
    /// <summary>
    /// 基础数据源
    /// </summary>
    public class EventData : IEventData
    {
        public EventData()
        {
            this.EventTime = DateTime.Now;
        }

        public DateTime EventTime { get; set; }
        public object Source { get; set; }
    }
}
