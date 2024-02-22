using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerSystem : InteractableScript
{
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
      
            VoiceDetector.level++;
            
        
        
    }
    
}
