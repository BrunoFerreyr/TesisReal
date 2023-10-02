using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipInteract : InteractableScript
{
    public VoiceDetector chipSystem;
    // Start is called before the first frame update
    public override void Interact(bool _doOnce)
    {
        base.Interact(_doOnce);
        chipSystem.enabled = true;
        chipSystem.actualHelpNumber ++;
        Destroy(this.gameObject);
    }
}
