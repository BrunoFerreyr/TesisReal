using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventVoiceButton : EventScript
{
    public EventDoor door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void DoEvent(int level)
    {
        base.DoEvent(level);
        eventStarted = true;
        Interaction();
    }

    void Interaction()
    {
        door.DoEvent(0);
    }
}
