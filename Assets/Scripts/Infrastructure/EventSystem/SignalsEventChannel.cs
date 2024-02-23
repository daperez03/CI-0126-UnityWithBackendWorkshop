using System;
using UnityWithBackendWorkshop.Domain;
using Zenject;

public class SignalsEventChannel : IEventChannel
{
    private readonly SignalBus _signalBus;

    public SignalsEventChannel(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Raise<TEvent>(TEvent @event) where TEvent : IEvent
    {
        _signalBus.Fire(@event);
    }

    public void Subscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
    {
        _signalBus.Subscribe(eventCallback);
    }

    public void Unsubscribe<TEvent>(Action<TEvent> eventCallback) where TEvent : IEvent
    {
        _signalBus.Unsubscribe(eventCallback);
    }
}