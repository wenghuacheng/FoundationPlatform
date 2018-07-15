using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.EventBus.Handlers
{
    public class ActionEventHandler<TEventData> : IEventHandler<TEventData> where TEventData : IEventData
    {
        public Action<TEventData> Action { get; private set; }
        public ActionEventHandler(Action<TEventData> action)
        {
            this.Action = action;
        }

        public void HandleEvent(TEventData eventData)
        {
            if (Action != null)
                Action(eventData);
        }
    }
}
