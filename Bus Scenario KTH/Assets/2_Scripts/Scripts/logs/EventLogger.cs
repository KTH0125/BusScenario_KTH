using System;
using System.IO;
using System.Text;
using UnityEngine;

public class EventLogger : MonoBehaviour
{

    private static readonly object innerLock = new object();
    private static string pName;
    private static string path;

    // Use this for initialization
    void OnEnable()
    {
        pName = PlayerPrefs.GetString("name");
        path = "Logs/" + ApplicationModel.startDate + "-" + pName + "-EventLog" + ".csv";
        
        File.AppendAllText(path, "Timestamp;Actor;Verb;Scene Object\n", Encoding.UTF8);
    }

    public static void Log(EventLog e)
    {
        print("start Log");
        Debug.Log(e.ToString());
        lock (innerLock)
        {
            File.AppendAllText(path, String.Format("{0};{1};\n", GlobalTime.globalTime, e.ToString()), Encoding.UTF8);
        }
    }

    public static string getPathEventLogger()
    {
        return path;
    }


}
