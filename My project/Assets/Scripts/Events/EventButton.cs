using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : EventInteract
{
    public override void DoEvent(int level)
    {
        if (_doCallback)
        {
            AddCallback(
                () => {
                    Debug.Log("EventCallPro");
                }
            );
        }
        base.DoEvent(level);
    }
}
