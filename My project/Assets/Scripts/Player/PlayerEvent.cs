using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvent
{
    static Dictionary<string, Action> eventsDictionary = new Dictionary<string, Action>();

    public static void CallEvent(string speechWord)
    {
        Debug.Log("call");
        if (eventsDictionary.ContainsKey(speechWord))
        {
            eventsDictionary.GetValueOrDefault(speechWord)?.Invoke();
        }
        else
        {
            SpeechRecognizer.Play();
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
