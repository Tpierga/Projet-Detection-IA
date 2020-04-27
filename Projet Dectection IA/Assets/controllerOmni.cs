using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerOmni : MonoBehaviour
{
    public SnapShotCamera snapCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snapCam.TakeSnapShot();
        }
        Forward();
        Rotate();
    }

    void Forward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-Vector3.forward * ((Time.deltaTime) * 2));
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up);
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * ((Time.deltaTime) * 2));
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(-Vector3.up);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(Vector3.up);
            }
        } 
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-Vector3.up);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up);
        }
    }
}
