using System;
using UnityEngine;

namespace UnityWithBackendWorkshop.Domain
{
    public interface IEventChannel
    {
        public void Raise<TEvent>(TEvent @event) 
            where TEvent : IEvent;

        public void Subscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent;

        public void Unsubscribe<TEvent>(Action<TEvent> eventCallback)
            where TEvent : IEvent;
    }
}
