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
        ShowText(1);
    }
   
    public virtual void Interact(bool _doOnce)
    {

    }
    public void ShowText(int showhide)
    {
        if (showhide == 0 && text != "")
        {            
            if (!hasInteracted)
            {
                textCanvas.ShowText(text);
            }           
        }
        else
        {
            textCanvas.HideText();
        }
    }
}
