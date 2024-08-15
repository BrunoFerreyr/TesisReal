using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvent
{
    static Dictionary<string, Action> eventsDictionary = new Dictionary<string, Action>();

    public static void CallEvent(string speechWord)
    {

        if (eventsDictionary.ContainsKey(speechWord))
        {
            eventsDictionary.GetValueOrDefault(speechWord)?.Invoke();
        }
    }

    public static void AddEventToList(string eventKey, Action action)
    {
        if (!eventsDictionary.ContainsKey(eventKey))
        {
            eventsDictionary.Add(eventKey, action);
        }
    }

    public static void DeleteEventFromList(string eventKey)
    {
        eventsDictionary.Remove(eventKey);
    }
}
