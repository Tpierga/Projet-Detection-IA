using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ConsoleApplication1;
using UnityEngine;

public class controllerOmni : MonoBehaviour
{
    public string sIP = "127.0.0.1";
    public int sPort = 50000;

    private UdpSocket server = new UdpSocket();
    private int _t = 0;

    public SnapShotCamera snapCam;
    // Start is called before the first frame update
    [SerializeField] private float rayDistance;
    private Vector3 vecteur_correction = new Vector3(-0.7f, 0.5f, 0);
    [SerializeField] private LayerMask layers;



    void Start()
    {
        server.Start(sIP, sPort, "test", verbose: true);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snapCam.TakeSnapShot();
            Debug.Log("snapshot Taken");
        }
        Forward();
        Rotate();
        //Sensors();
    }

    private void LateUpdate()
    {
        var bytes = snapCam.EncodeImage();
        if (bytes != null && bytes.Length > 0)
        {
            server.SendImageTo("127.0.0.1", 28000, bytes);
        }
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
    
    void Sensors()
    {
        RaycastHit hit;
         Debug.DrawRay(transform.position+vecteur_correction , transform.TransformDirection(-Vector3.forward) * rayDistance, Color.red);       
         if (Physics.Raycast(transform.position +vecteur_correction , transform.TransformDirection(-Vector3.forward) * rayDistance, out hit, rayDistance,layers))
         {
             Debug.Log("aie");
                 transform.Rotate(-Vector3.up);
         }
    }
    
}
