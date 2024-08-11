using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerSystem : InteractableScript
{
    [SerializeField] GameObject canvas;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact(bool _doOnce)
    {
        base.Interact(_doOnce);
        light.color = Color.red;
        transform.GetChild(1).GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.red);
        canvas.SetActive(false);   
        VoiceDetector.level++;  
    }    
}
