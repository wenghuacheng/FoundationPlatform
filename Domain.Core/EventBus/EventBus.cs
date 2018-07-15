using Domain.Core.EventBus.Handlers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.EventBus
{
    public class EventBus : IEventBus
    {
        private static readonly EventBus _instance = new EventBus();
        public static EventBus Default => _instance;

        private readonly ConcurrentDictionary<Type, List<IDomainService>> _handlers;

        public EventBus()
        {
            _handlers = new ConcurrentDictionary<Type, List<IDomainService>>();
        }

        #region Register
        public IEventHandler<TEventData> Register<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            var result = new ActionEventHandler<TEventData>(action);
            Register(result);
            return result;
        }

        public void Register<TEventData>(IEventHandler<TEventData> action) where TEventData : IEventData
        {
            if (_handlers.Keys.Contains(typeof(TEventData)))
            {
                var eventHandlers = _handlers[typeof(TEventData)];
                if (!eventHandlers.Contains(action))
                {
                    eventHandlers.Add(action);
                }
            }
            else
            {
                _handlers.TryAdd(typeof(TEventData), new List<IDomainService>() { action });
            }
        }
        #endregion

        #region UnRegister
        public void UnRegister<TEventData>(Action<TEventData> action) where TEventData : IEventData
        {
            var list = _getInstances<TEventData>();
            list.RemoveAll(p =>
            {
                var handler = p as ActionEventHandler<TEventData>;
                if (handler == null)
                {
                    return false;
                }
                return handler.Action == action;
            });
        }

        public void UnRegister<TEventData>(IEventHandler<TEventData> action) where TEventData : IEventData
        {
            var list = _getInstances<TEventData>();
            list.RemoveAll(p =>
            {
                return p == action;
            });
        }
        #endregion        

        public void Trigger<TEventData>(TEventData eventData) where TEventData : IEventData
        {
            var list = _getInstances<TEventData>();
            list.ForEach(p =>
            {
                var action = p as IEventHandler<TEventData>;
                if (action != null)
                    action.HandleEvent(eventData);
            });
        }

        /// <summary>
        /// 触发通过注入的实例
        /// </summary>
        /// <typeparam name="TEventData"></typeparam>
        /// <param name="container"></param>
        /// <param name="eventData"></param>
        //public void TriggerInjection<TEventData>(IContainer container, TEventData eventData) where TEventData : IEventData
        //{
        //    var list = _getInstances<TEventData>();
        //    //autofac小技巧，在需要获取全部实例时，改为集合类即可
        //    var injectlist = container.Resolve<IEnumerable<IEventHandler<TEventData>>>();
        //    var instances = list.Union(injectlist).ToList();
        //    instances.ForEach(p =>
        //    {
        //        var action = p as IEventHandler<TEventData>;
        //        if (action != null)
        //            action.HandleEvent(eventData);
        //    });
        //}

        private List<IDomainService> _getInstances<TEventData>() where TEventData : IEventData
        {
            if (_handlers.ContainsKey(typeof(TEventData)))
            {
                var list = _handlers[typeof(TEventData)];
                return list;
            }
            return new List<IDomainService>();
        }
    }
}
