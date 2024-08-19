using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    [SerializeField]protected string id;
    public GameObject eventObject;
    public bool eventStarted;
    public int type;
    public Image sprite;
    public bool haveSprite;

    public bool doOnce;

    private float _callbackTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SpeechRecognizer.doingAction = false;
        }
        Debug.Log(SpeechRecognizer.doingAction);
    }
    public virtual void BuildEvent(int _type)
    {
        if (!eventStarted && type == _type)
        {
            DoEvent(VoiceDetector.level);
            //Sientra aca, hace el evento con normalidad.
           /* coroutine = StartEvent();
            StartCoroutine(coroutine);*/
        }
    }
    public virtual void BuildEvent()
    {
        if (!eventStarted)
        DoEvent(VoiceDetector.level);
    }
    public virtual void DoEvent(int level)
    {
        SpeechRecognizer.Stop();
        StartCoroutine(EndEvent());
    }

    public IEnumerator EndEvent()
    {

        yield return new WaitForSeconds(_callbackTime);
        Debug.Log("end");
        SpeechRecognizer.Play();

        SpeechRecognizer.doingAction = false;
    }
    public void ChangeSprite()
    {
        if(haveSprite)
        {
            if (sprite == null)
            {
                Debug.Log("SPRITE NULL");
            }
            sprite.color = new Color(255, 255, 0);
        }
        
    }
    public void WhiteSprite()
    {
        if (haveSprite)
        {
            if (sprite == null)
            {
                Debug.Log("SPRITE NULL");
            }
            sprite.color = new Color(255, 255, 255);
        }
       
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("coll");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEvent.AddEventToList(id,BuildEvent);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEvent.DeleteEventFromList(id);
        }
    }
    ///Cuando me acerco a un evento, la palabra se pone en amarillo. al interactuar apagar luz, pulsa e para interactuar.
}
