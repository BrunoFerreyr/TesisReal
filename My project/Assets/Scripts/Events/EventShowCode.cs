using System.Collections;
using System.Collections.Generic;
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
    public override void DoEvent()
    {
        base.DoEvent();
        coroutine = StartEvent();

        visionCollider.enabled = true;

        StartCoroutine(coroutine);
        
        
    }
    public IEnumerator StartEvent()
    {
        eventStarted = true;

        if (hasInformation)
        {
            eventObject.SetActive(true);
            door.HasUsedVision = true;
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
                }
            }
        }
        eventStarted = false;
        Debug.Log("door" + door.HasUsedVision);

        if(hasInformation)
        eventObject.SetActive(false);
    }

  
}