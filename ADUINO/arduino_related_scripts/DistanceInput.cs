using UnityEngine;
using System.IO.Ports;

public class DistanceInput : MonoBehaviour
{
    public string portName = "/dev/tty.usbmodemXXXX"; // macOS
    // Windows 示例："COM3"

    public float value; // 0–1

    SerialPort serial;

    void Start()
    {
        serial = new SerialPort(portName, 9600);
        serial.ReadTimeout = 20;
        serial.Open();
    }

    void Update()
    {
        if (serial != null && serial.IsOpen)
        {
            try
            {
                string line = serial.ReadLine();
                value = Mathf.Clamp01(float.Parse(line));
            }
            catch { }
        }
    }

    void OnDestroy()
    {
        if (serial != null && serial.IsOpen)
            serial.Close();
    }
}