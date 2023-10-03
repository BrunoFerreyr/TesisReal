using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHelp : EventScript
{
    // Start is called before the first frame update
    public List<GameObject> guideObjects;
    public Material[] originalMaterials;
    public Material[] materialColor;
    public Material brightMaterial;
    void Start()
    {
        materialColor= new Material[guideObjects[0].GetComponent<MeshRenderer>().materials.Length];
        for(int i = 0; i < materialColor.Length; i++)
        {
            materialColor[i] = brightMaterial;
        }
        originalMaterials = new Material[guideObjects[0].GetComponent<MeshRenderer>().materials.Length];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void DoEvent(int _level)
    {
        base.DoEvent(_level);
        for(int x= 0; x < guideObjects.Count; x++)
        {
            //originalMaterials.Add(guideObjects[x].GetComponent<MeshRenderer>().material);
            //guideObjects[x].GetComponent<MeshRenderer>().material = materialColor;
            originalMaterials = guideObjects[0].GetComponent<MeshRenderer>().materials;

            for (int i = 0; i < guideObjects[x].GetComponent<MeshRenderer>().materials.Length; i++)
            {
                Debug.Log("help" + guideObjects[x].GetComponent<MeshRenderer>().materials.Length);

                guideObjects[x].GetComponent<MeshRenderer>().materials = materialColor;
               // guideObjects[x].GetComponent<MeshRenderer>().materials[2] = materialColor;
            }
        }
        StartCoroutine("ShowGuide");
    }

    public IEnumerator ShowGuide()
    {
        yield return new WaitForSeconds(4);
        for (int x = 0; x < guideObjects.Count; x++)
        {            
            /*for(int i = 0; i < guideObjects[x].GetComponent<MeshRenderer>().materials.Length; i++)
            {
                guideObjects[x].GetComponent<MeshRenderer>().materials[i] = originalMaterials[x];
            }*/
            guideObjects[0].GetComponent<MeshRenderer>().materials = originalMaterials;
        }
        //originalMaterials.Clear();
    }
}
