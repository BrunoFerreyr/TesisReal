using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInteract : EventScript
{
    // Start is called before the first frame update
    [SerializeField] protected bool _doCallback = false;
    [SerializeField] private Interactable _interactable = null;
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
        _interactable.DoInteraction();
    }

    public virtual void EndInteraction()
    {
        eventStarted = false;
    }

    protected void AddCallback(Action callback)
    {
        _interactable.EndTurningOnEvent += callback;
    }
}
