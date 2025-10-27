using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEventScript : EventScript
{
    [SerializeField] protected GameObject eventObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("coll");
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEvent.AddEventToList(id, BuildEvent);
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerEvent.DeleteEventFromList(id);
        }
    }
}
