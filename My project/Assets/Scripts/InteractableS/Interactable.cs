using System;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected Animator animator = null;
    [SerializeField] protected bool turnedOn = false;
    // Start is called before the first frame update  
    public event Action EndTurningOnEvent = delegate { };
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) { EndTurningOn(); }
    }
    public void EndTurningOn()
    {
        EndTurningOnEvent();
    }
    public abstract void DoInteraction();
}
