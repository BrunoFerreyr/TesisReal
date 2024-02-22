using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventScript : MonoBehaviour
{
    public GameObject eventObject;
    public bool eventStarted;
    public int type;
    public Image sprite;
    public bool haveSprite;
    IEnumerator coroutine;

    public bool doOnce;
    public bool hasInteracted;
    public bool isText = false;

    public ShowTextScript textCanvas;
    public string text;
    public bool firstTime;
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
    
    
    ///Cuando me acerco a un evento, la palabra se pone en amarillo. al interactuar apagar luz, pulsa e para interactuar.
}
