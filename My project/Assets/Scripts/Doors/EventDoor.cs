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
        /*if (move)
        {
           // float pos = this.transform.GetChild(0).transform.localPosition.y - openPosition.y;
           // eventObject.transform.localPosition = Vector3.MoveTowards(eventObject.transform.localPosition, openPosition, Time.deltaTime*4);
            //Debug.Log("dontmove"+ pos);
            if (eventObject.transform.localPosition.y -openPosition.y >= -0.5f)
            {
                move = false;
                eventStarted = false;
                Debug.Log("dontmove");
               // ShowText();
                firstTime = false;
                VoiceDetector.actualHelpNumber++;
            }
            //SmoothDamp investigar
        }*/
        
    }
    public override void DoEvent(int _level)
    {
        base.DoEvent(_level);
        Debug.Log("DoEvent");

        if (needsKey)
        {
            if (keyFounded)
            {
                GetComponent<Animator>().SetTrigger("DoorTrigger");
                eventStarted = true;
                move = true;
            }
        }
        else
        {
            GetComponent<Animator>().SetTrigger("DoorTrigger");

            eventStarted = true;
            move = true;

        }

        //this.transform.GetChild(0).transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
        //this.transform.GetChild(0).transform.localPosition = Vector3.MoveTowards(this.transform.GetChild(0).transform.localPosition, openPosition, Time.deltaTime);
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !firstTime && isAutomatic)
        {
            GetComponent<Animator>().SetTrigger("DoorTrigger");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && !firstTime && isAutomatic)
        {
            GetComponent<Animator>().SetTrigger("DoorTrigger");
        }
    }
}
