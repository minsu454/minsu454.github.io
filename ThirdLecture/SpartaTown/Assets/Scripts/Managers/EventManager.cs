using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public delegate void EventListener(object args);

public class EventManager
{
    private Dictionary<GameEventType, List<EventListener>> eventListenerDic = new Dictionary<GameEventType, List<EventListener>>();

    public void Subscribe(GameEventType type, EventListener listener)
    {
        if (!eventListenerDic.TryGetValue(type, out var list))
        {
            list = new List<EventListener>();
            eventListenerDic[type] = list;
        }

        list.Add(listener);
    }

    public void Unsubscribe(GameEventType type, EventListener listener)
    {
        if (!eventListenerDic.TryGetValue(type, out var list))
        {
            return;
        }

        list.Remove(listener);
        if (list.Count == 0)
        {
            eventListenerDic.Remove(type);
        }
    }

    public void Dispatch(GameEventType type, object arg)
    {
        if (!eventListenerDic.TryGetValue(type, out var list))
        {
            return;
        }   

        foreach (var listener in list)
        {
            try
            {
                listener.Invoke(arg);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
