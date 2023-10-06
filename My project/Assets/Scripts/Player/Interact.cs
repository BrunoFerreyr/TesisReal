using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            other.gameObject.GetComponent<InteractableScript>().ShowText();
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            

            if (Input.GetKeyDown(KeyCode.E))
            {
                other.gameObject.GetComponent<InteractableScript>().DoInteract();
                other.gameObject.GetComponent<InteractableScript>().ShowText();
                if (other.gameObject.GetComponent<InteractableScript>().doOnce)
                {
                    other.gameObject.GetComponent<InteractableScript>().hasInteracted = true;
                    other.gameObject.GetComponent<BoxCollider>().enabled = false;
                }

            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            if (!other.gameObject.GetComponent<InteractableScript>().hasInteracted)
            {
                other.gameObject.GetComponent<InteractableScript>().ShowText();
            }
        }
    }
}
