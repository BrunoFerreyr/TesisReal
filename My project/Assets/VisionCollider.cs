using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCollider : MonoBehaviour
{
    // Start is called before the first frame update
    
    public List<GameObject> gameObjectsToHide;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hidden")
        {
            if (other.gameObject.layer == 9)
            {
                gameObjectsToHide.Add(other.gameObject);
                other.gameObject.layer = 8;
            }

        }
    }

    public void CleanList()
    {
        gameObjectsToHide.Clear();
    }
}
