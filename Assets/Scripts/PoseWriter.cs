using UnityEngine;
using TMPro;
using System.IO;
using System;


public class PoseWriter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI filePathText;
    
    private StreamWriter writer;

    void Start()
    {
        string file = Path.Combine(Application.persistentDataPath, DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".csv");
        filePathText.text = file;
        writer = new StreamWriter(file);
        Debug.Log($"write to {file}", this);
    }

    void OnDestroy()
    {
        writer.Flush();
        writer.Close();
        Debug.Log("log file has been closed", this);
    }

    public void Write(Vector3 pos, Quaternion rot)
    {
        writer.WriteLine($"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffffff")},{pos.x},{pos.y},{pos.z},{rot.x},{rot.y},{rot.z},{rot.w}");
    }
}
