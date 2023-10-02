using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public GameObject eventObject;
    public bool eventStarted;
    public int type;
    IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
     
    public virtual void DoEvent(int level)
    {

    }
    
}
