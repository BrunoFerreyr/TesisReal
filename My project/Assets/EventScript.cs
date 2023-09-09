using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public GameObject eventObject;
    public bool eventStarted;
    public int type;
    IEnumerator coroutine;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void BuildEvent(int _type,int _level)
    {
        if (!eventStarted && type == _type)
        {
            DoEvent(_level);
            //Sientra aca, hace el evento con normalidad.
           /* coroutine = StartEvent();
            StartCoroutine(coroutine);*/
        }
    }

    public virtual void DoEvent(int level)
    {

    }
    
}
