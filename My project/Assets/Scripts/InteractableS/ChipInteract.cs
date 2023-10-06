using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipInteract : InteractableScript
{
    public VoiceDetector chipSystem;
    public GameObject canvasWords;
    // Start is called before the first frame update
    public override void Interact(bool _doOnce)
    {
        base.Interact(_doOnce);
        chipSystem.enabled = true;
        VoiceDetector.actualHelpNumber ++;
        canvasWords.SetActive(true);

        Destroy(this.gameObject);
    }
    public override void ShowText()
    {
        Debug.Log("TriggEnter");
        if (!isText)
        {
            textCanvas.ShowText(text);
        }
        base.ShowText();

    }
}
