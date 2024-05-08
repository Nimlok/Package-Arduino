using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SerialController))]
public class SerialListener : MonoBehaviour
{
    [SerializeField] SerialController controller;
    void Reset() => controller = GetComponent<SerialController>();

    /// <summary>
    /// Called when a message is received from the serial port 
    /// </summary>
    /// <param name="_msg">string read from serial port</param>
    void OnMessageArrived(string _msg)
    {
        //
        Debug.Log($"[{controller.portName}] {_msg}");
    }

    /// <summary>
    /// Called when the connection status of the serial port changes
    /// </summary>
    /// <param name="_success">true if device connected, false if disconnected</param>
    void OnConnectionEvent(bool _success)
    {
        if (_success) { Debug.Log("arduino found"); }

        else if (!_success) { Debug.Log("arduino disconnected"); }
    }

    /// <summary>
    /// Writes a string to the serial port.
    /// Write just a single character for best effect.
    /// </summary>
    public void Write(string _msg) => controller.SendSerialMessage(_msg);

    void Update()
    {
        //Example - single characters being sent to the arduino work best
        if (Input.GetKeyDown(KeyCode.A)) { Write("A"); }
        else if (Input.GetKeyDown(KeyCode.Z)) { Write("Z"); }
    }
}
