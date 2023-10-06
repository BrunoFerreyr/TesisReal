using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventButton : InteractableScript
{
    public EventDoor door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact(bool _doOnce)
    {
        base.Interact(_doOnce);
        door.DoEvent(0);
        Debug.Log("interact");
    }
    public override void ShowText()
    {
        if (!isText)
        {
            textCanvas.ShowText(text);
        }
        base.ShowText();
        Debug.Log("TriggEnter");
        
        
    }


}
