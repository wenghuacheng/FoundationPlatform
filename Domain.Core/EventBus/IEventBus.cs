using Domain.Core.EventBus.Handlers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.EventBus
{
    public interface IEventBus
    {
        #region Register
        IEventHandler<TEventData> Register<TEventData>(Action<TEventData> action) where TEventData : IEventData;

        void Register<TEventData>(IEventHandler<TEventData> action) where TEventData : IEventData;
        #endregion

        #region UnRegister
        void UnRegister<TEventData>(Action<TEventData> action) where TEventData : IEventData;

        void UnRegister<TEventData>(IEventHandler<TEventData> action) where TEventData : IEventData;
        #endregion

        #region  Trigger
        void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData;

        //void TriggerInjection<TEventData>(IContainer container, TEventData eventData) where TEventData : IEventData;
        #endregion
    }
}
