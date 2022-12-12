using System;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class SerialReceiver : MonoBehaviour
{
    private SerialPort stream;

    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort(SerialPort.GetPortNames()[0], 115200);
        stream.ReadTimeout = 5;
        stream.Open();
    }

    // Update is called once per frame
    void Update()
    {
        string serialString = stream.ReadLine();
        player.ReceiveFrequency(float.Parse(serialString));
    }


}