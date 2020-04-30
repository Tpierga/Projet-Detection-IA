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
    void Start()
    {
        server.Start(sIP, sPort, "test", verbose: true);
        Debug.Log("server started");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        sending_ping(100);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snapCam.TakeSnapShot();
        }
        Forward();
        Rotate();
    }

    void sending_ping(int waitingTime)
    {
        _t += 1;
        if (_t == waitingTime)
        {
            server.SendTo(sIP, sPort, "ping");
            Debug.Log("send ping");
            _t = 0;
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
}
