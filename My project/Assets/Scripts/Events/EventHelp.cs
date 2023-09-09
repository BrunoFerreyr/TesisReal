using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHelp : EventScript
{
    // Start is called before the first frame update
    public List<GameObject> guideObjects;
    public List<Material> originalMaterials;
    public Material materialColor;
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

        for(int x= 0; x< guideObjects.Count; x++)
        {
            originalMaterials.Add(guideObjects[x].GetComponent<MeshRenderer>().material);
            guideObjects[x].GetComponent<MeshRenderer>().material = materialColor;
        }
        StartCoroutine("ShowGuide");
    }

    public IEnumerator ShowGuide()
    {
        yield return new WaitForSeconds(4);
        for (int x = 0; x < guideObjects.Count; x++)
        {            
            guideObjects[x].GetComponent<MeshRenderer>().material = originalMaterials[x];
        }
        originalMaterials.Clear();
    }
}
