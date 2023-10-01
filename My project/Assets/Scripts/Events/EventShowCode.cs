using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventShowCode : EventScript
{

    IEnumerator coroutine;
   

    public EventDoor door;
    public SphereCollider visionCollider;
    public Material transparentMaterial;
    public List<Material> originalMaterials;

    public int time = 4;
    public bool hasInformation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoEvent(int _level)
    {
        base.DoEvent(_level);
        coroutine = StartEvent();

        visionCollider.enabled = true;

        StartCoroutine(coroutine);
        
        
    }
    public IEnumerator StartEvent()
    {
        eventStarted = true;
        visionCollider.enabled = true;

        if (hasInformation)
        {
            eventObject.SetActive(true);
            door.keyFounded = true;
        }

        yield return new WaitForSeconds(0.25f);
        if (!hasInformation)
        {

            eventStarted = true;

            visionCollider.enabled = false;
            for (int x = 0; x < visionCollider.GetComponent<VisionCollider>().gameObjectsToHide.Count; x++)
            {
                if (visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].GetComponent<MeshRenderer>() != null)
                {
                    originalMaterials.Add(visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].GetComponent<MeshRenderer>().material);
                    visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].GetComponent<MeshRenderer>().material = transparentMaterial;
                }
            }

        }

        yield return new WaitForSeconds(time);
      
        
        if (!hasInformation)
        {
            for (int x = 0; x < visionCollider.GetComponent<VisionCollider>().gameObjectsToHide.Count; x++)
            {
                if (visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].GetComponent<MeshRenderer>() != null)
                {

                    visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].GetComponent<MeshRenderer>().material = originalMaterials[x];
                    visionCollider.GetComponent<VisionCollider>().gameObjectsToHide[x].layer = 9;
                }
            }
            visionCollider.GetComponent<VisionCollider>().CleanList();
            originalMaterials.Clear();
        }
        eventStarted = false;

        if(hasInformation)
        eventObject.SetActive(false);
    }
    // Tengo que hacer lo de los niveles, para hacer el codigo verifica aca si esta colisionando uno del otro, solo hay un collider 
    //    con el evento showcode, el gigante. 
  
}
