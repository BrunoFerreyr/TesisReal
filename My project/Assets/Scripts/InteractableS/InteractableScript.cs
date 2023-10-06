using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableScript : MonoBehaviour
{
    public bool collisionEnabled;
    public bool doOnce;
    public bool hasInteracted;
    public bool isText = false;

    public ShowTextScript textCanvas;
    public string text;
    // Start is called before the first frame update
    public virtual void DoInteract()
    {
        if(collisionEnabled)
        Interact(doOnce);
    }
   
    public virtual void Interact(bool _doOnce)
    {

    }
    public virtual void ShowText()
    {
        if (!isText)
        {
            
            if (!hasInteracted)
            {
                textCanvas.gameObject.SetActive(true);
                isText = true;
            }
            
        }
        else
        {
            textCanvas.gameObject.SetActive(false);
            isText = false;
        }
    }
}
