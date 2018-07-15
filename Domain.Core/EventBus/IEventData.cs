using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.EventBus
{
    /// <summary>
    ///  事件源接口
    /// </summary>
    public interface IEventData
    {
        DateTime EventTime { get; set; }

        object Source { get; set; }
    }
}
