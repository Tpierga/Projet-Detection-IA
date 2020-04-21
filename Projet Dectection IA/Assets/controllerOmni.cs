using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerOmni : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * 20));
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up);
        }
    }
}
