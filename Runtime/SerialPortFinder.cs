using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialPortFinder : MonoBehaviour
{
    [SerializeField] List<string> foundPorts = new();

    void Awake() => FindConnectedDevices();

    [ContextMenu("FindPorts")]
    void FindConnectedDevices()
    {
        foundPorts.Clear();
        foreach (string portName in SerialPort.GetPortNames())
        {
            if (!portName.Contains("usbmodem") &&
                !portName.Contains("usbserial") &&
                !portName.Contains("COM"))
                continue;

            Debug.Log($"Port found: {portName}");
            foundPorts.Add(portName);
        }
    }
}
