using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMoveObjects : EventScript
{
    // Start is called before the first frame update
    public float strenght;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoEvent(int _level)
    {
        base.DoEvent(_level);
        eventStarted = true;
        PushObjects();
    }
    public void PushObjects()
    {
        for(int x = 0; x < eventObject.transform.childCount; x++)
        {
            eventObject.transform.GetChild(x).GetComponent<Rigidbody>().AddExplosionForce(strenght, eventObject.transform.position,1000);
        }
        eventStarted = false;
    }
}
