using Microsoft.Practices.Prism.Events;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPrismDemo.Infrastructure
{
    public class ConcurrentEventAggregator : IEventAggregator
    {
        private readonly ConcurrentDictionary<Type, EventBase> events = new ConcurrentDictionary<Type, EventBase>();

        public TEventType GetEvent<TEventType>() where TEventType : EventBase, new()
        {
            return (TEventType)this.events.GetOrAdd(typeof(TEventType), Activator.CreateInstance<TEventType>());
        }
    }
}
