using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class EventDoor : EventScript
{
    [SerializeField] Renderer padMaterial;
    [SerializeField] Animator _doorAnimator;
    public bool keyFounded;
    public bool needsKey;
    // Start is called before the first frame update
    void Start()
    {
        if (!needsKey)
        {
            padMaterial.material.SetColor("_EmissionColor", Color.green);
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
                _doorAnimator.SetBool("Opened", true);
                eventStarted = true;
            }
        }
        else
        {
            _doorAnimator.SetBool("Opened", true);

            eventStarted = true;
        }
    }  
    

    public void OpenEmission()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);           
    }

    public void CloseEmission()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.tag == "Player" && _doorAnimator.GetBool("Opened"))
        {
            _doorAnimator.SetBool("Opened", false);
        }
    }
}
