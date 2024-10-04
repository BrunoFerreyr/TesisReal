using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    
    public override void DoInteraction()
    {
        if (!turnedOn) //Se enciende
        {
            animator.SetBool("turnedOn", true);
        }
        else //Se apaga
        {
            animator.SetBool("turnedOn", false);
        }
        Debug.Log("Interacciona");
    }

}
