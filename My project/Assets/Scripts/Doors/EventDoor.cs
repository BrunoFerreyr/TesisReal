using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class EventDoor : EventScript
{
    Vector3 openPosition;
    bool move;  

    public bool keyFounded;
    public bool needsKey;
    // Start is called before the first frame update
    void Start()
    {
        openPosition = new Vector3(eventObject.transform.localPosition.x, eventObject.transform.localPosition.y + 6, eventObject.transform.localPosition.z);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            move = true;
        }
        if (move)
        {
           // float pos = this.transform.GetChild(0).transform.localPosition.y - openPosition.y;
            eventObject.transform.localPosition = Vector3.MoveTowards(eventObject.transform.localPosition, openPosition, Time.deltaTime*4);
            //Debug.Log("dontmove"+ pos);
            if (eventObject.transform.localPosition.y -openPosition.y >= -0.5f)
            {
                move = false;
                eventStarted = false;
                Debug.Log("dontmove");
            }
            //SmoothDamp investigar
        }
        
    }
    public override void DoEvent(int _level)
    {
        base.DoEvent(_level);
        Debug.Log("DoEvent");

        if (needsKey)
        {
            if (keyFounded)
            {
                eventStarted = true;
                move = true;
            }
        }
        else
        {
            eventStarted = true;
            move = true;

        }

        //this.transform.GetChild(0).transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
        //this.transform.GetChild(0).transform.localPosition = Vector3.MoveTowards(this.transform.GetChild(0).transform.localPosition, openPosition, Time.deltaTime);
    }   
}
