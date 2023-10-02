using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    int type;
    public int number;
    public GameObject eventObject;
    public EventDoor door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Show()
    {
        eventObject.SetActive(true);
        door.keyFounded = true;
        if (type == 0)
        {

        }
    }
    public void Hide()
    {
        eventObject.SetActive(false);
    }
}
