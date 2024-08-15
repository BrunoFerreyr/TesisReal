using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventShowObject : EventScript
{
    public int number;
    [SerializeField] private float _activatedTime;
    public EventDoor door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoEvent(int level)
    {
        base.DoEvent(level);
        Show();
    }
    public void Show()
    {
        eventStarted = true;
        eventObject.SetActive(true);
        Invoke("Hide",_activatedTime);
        if(door != null)
        {
            door.keyFounded = true;
        }
    }
    public void Hide()
    {
        eventObject.SetActive(false);
        eventStarted = false;
    }
}
