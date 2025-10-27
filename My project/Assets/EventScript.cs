using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    [SerializeField]protected string id;
    public bool eventStarted;

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
    }
    public virtual void BuildEvent()
    {
        if (!eventStarted)
        DoEvent(0);
    }
    public virtual void DoEvent(int level)
    {
        Debug.Log("DoEvent");
        SpeechRecognizer.Stop();
        StartCoroutine(EndEvent());
    }

    public IEnumerator EndEvent()
    {

        yield return new WaitForSeconds(_callbackTime);
        Debug.Log("end");
        SpeechRecognizer.Play();
    }
}
