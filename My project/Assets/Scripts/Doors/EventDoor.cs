using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class EventDoor : EventScript
{
    Vector3 openPosition;
    bool move;

    [SerializeField] Renderer padMaterial;
    public bool keyFounded;
    public bool needsKey;
    [SerializeField] bool isAutomatic;
    // Start is called before the first frame update
    void Start()
    {
        openPosition = new Vector3(eventObject.transform.localPosition.x, eventObject.transform.localPosition.y + 6, eventObject.transform.localPosition.z);
        if (!needsKey)
        {
            padMaterial.material.SetColor("_EmissionColor", Color.green);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            move = true;
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
                GetComponent<Animator>().SetBool("Opened", true);
                eventStarted = true;
                move = true;
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("Opened", true);

            eventStarted = true;
            move = true;

        }
    }  
    

    public void OpenEmission()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        if (firstTime)
        {
            move = false;
            eventStarted = false;
            Debug.Log("dontmove");
            textCanvas.HideText();
            firstTime = false;
            VoiceDetector.actualHelpNumber++;
        }       
    }

    public void CloseEmission()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        if (other.gameObject.tag == "Player" && !firstTime && isAutomatic)
        {
            GetComponent<Animator>().SetBool("Opened", false);
        }
    }
}
