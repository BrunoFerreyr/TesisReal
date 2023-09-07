using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public bool collisionEnabled;
    public bool doOnce;
    // Start is called before the first frame update
    public virtual void DoInteract()
    {
        if(collisionEnabled)
        Interact(doOnce);
    }
    public virtual void Interact(bool _doOnce)
    {

    }
}
