using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningOnOfCollider : MonoBehaviour
{
    [SerializeField] bool intoTheZone = false;
    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            intoTheZone = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
