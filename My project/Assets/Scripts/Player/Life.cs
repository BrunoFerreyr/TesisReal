using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public Vector3 checkpoint;

    // Start is called before the first frame update
    void Start()
    {
        checkpoint = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Die("Fire");
        }
    }

    public void Die(string killerName)
    {
        this.GetComponent<CharacterController>().enabled = false;
        this.transform.position = checkpoint;
        this.GetComponent<CharacterController>().enabled = true;

        Debug.Log("WTF");

    }
}
