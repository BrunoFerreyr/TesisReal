using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerEvent
{
    public static Dictionary<string, Action> eventsDictionary{ get; private set; }

    public static void CallEvent(string speechWord)
    {
        if (eventsDictionary.ContainsKey(speechWord))
        {
            Debug.Log("call");
            eventsDictionary.GetValueOrDefault(speechWord)?.Invoke();
        }
        else
        {
            SpeechRecognizer.Play();
        }
    }

    public static void AddEventToList(string eventKey, Action action)
    {
        eventsDictionary ??= new Dictionary<string, Action>();
        Debug.Log("even = " + eventKey + " //// count = " + eventsDictionary.Count);
        if (!eventsDictionary.ContainsKey(eventKey))
        {
            eventsDictionary.Add(eventKey, action);
            UIWordsSystem.Instance.UpdateWords();
        }
    }

    public static void DeleteEventFromList(string eventKey)
    {
        eventsDictionary.Remove(eventKey);
        UIWordsSystem.Instance.DeleteWord(eventKey);
    }
}
