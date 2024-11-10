using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCameraChange : EventScript
{
    // Start is called before the first frame update
    public override void DoEvent(int level)
    {
        base.DoEvent(level);
        MouseLook.isThirdPerson = !MouseLook.isThirdPerson;
    }
}
