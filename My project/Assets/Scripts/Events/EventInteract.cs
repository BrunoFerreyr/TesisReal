using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteract : EventScript
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void DoEvent(int level)
    {
        base.DoEvent(level);
        StartInteraction();
    }

    public virtual void StartInteraction()
    {
        eventStarted = true;
    }

    public virtual void EndInteraction()
    {
        eventStarted = false;
    }
}
