using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player object
    [SerializeField] private Transform cameraPosition;
    public float switchDistance;
    private bool haveChanged = false;
    void Update()
    {
        // Check if player is within the zone's switch distance
        if (Vector3.Distance(transform.position, player.position) < switchDistance && !MouseLook.isThirdPerson)
        {
            Debug.Log("FIND");
            // Smoothly move the camera to the new position
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, cameraPosition.position, 1);
            Camera.main.transform.rotation = Quaternion.Lerp(Camera.main.transform.rotation, cameraPosition.rotation, 1);
            haveChanged = true;
        }
    }
}
