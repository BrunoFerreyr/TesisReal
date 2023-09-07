using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensivity;

    float rotationX;
    float rotationY;

    public Transform player;
    public int targetFrameRate = 120;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX,-90,90);
        //Debug.Log("mouseX" + mouseX + "floaty" + mouseY);
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        player.Rotate(Vector3.up * mouseX);
        // rotationY += mouseX;

        transform.localRotation = Quaternion.Euler(rotationX,0,0);

        //player.eulerAngles=new Vector3(0,this.transform.eulerAngles.y,0);
    }
    
}
