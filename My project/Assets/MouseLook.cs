using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensivity;

    float rotationX;
    float rotationY;

    float mouseX;
    float mouseY;

    [SerializeField] private Transform playerHead;
    [SerializeField] private Transform target;
    public int targetFrameRate = 120;

    public static bool isThirdPerson = false;
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
        if (isThirdPerson)
        {
            mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -90, 90);
            //Debug.Log("mouseX" + mouseX + "floaty" + mouseY);
            mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
            Debug.Log("mouseX" + mouseX);
            //player.Rotate(Vector3.up * mouseX);
            rotationY += mouseX;

            transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0);

            //player.eulerAngles=new Vector3(0,this.transform.eulerAngles.y,0);
        }
     
        if (Input.GetKeyDown(KeyCode.J))
        {
            isThirdPerson = !isThirdPerson;
            transform.position = playerHead.position;
            mouseX = 0;
            mouseY = 0;
            rotationX = playerHead.eulerAngles.x;
            rotationY = playerHead.eulerAngles.y;
        }
    }
    
}
