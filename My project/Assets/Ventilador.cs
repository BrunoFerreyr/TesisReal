using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ventilador : MonoBehaviour
{
    Transform rotation;
    [SerializeField] float speed;

    private void Start()
    {
        rotation = transform.GetChild(1).transform;
    }
    // Start is called before the first frame update
    private void Update()
    {
        rotation.Rotate(new Vector3(0,speed,0));
    }
}
