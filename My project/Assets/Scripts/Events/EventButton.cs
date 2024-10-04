using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : EventInteract
{
    // Start is called before the first frame update
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
