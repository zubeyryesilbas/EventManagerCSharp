using System;
using System.Collections.Generic;

public class EventManager
{
    private static EventManager instance;

    private Dictionary<string, List<Action<object>>> eventListeners = new Dictionary<string, List<Action<object>>>();

    public static EventManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }
    }

    public void AddEventListener(string eventName, Action<object> action)
    {
        if (!eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName] = new List<Action<object>>();
        }

        eventListeners[eventName].Add(action);
    }

    public void RemoveEventListener(string eventName, Action<object> action)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            eventListeners[eventName].Remove(action);
        }
    }

    public void TriggerEvent(string eventName, object eventData = null)
    {
        if (eventListeners.ContainsKey(eventName))
        {
            foreach (var action in eventListeners[eventName])
            {
                action.Invoke(eventData);
            }
        }
    }
}
