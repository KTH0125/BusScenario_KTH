using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class PointCollider : MonoBehaviour {

    // Use this for initialization

    public string playerName;

    private string sollicitationToLog;

    void Start () {
        playerName = PlayerPrefs.GetString("name");
        sollicitationToLog = "";
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        print("---->>>>>PointCollider : "+ other.gameObject.name);
        if (other.gameObject.name == "Camera(head)")
            sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", marche sur, " + this.name +"\n";
       
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Camera(head)")
            sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", ne marche plus sur, " + this.name+ "\n";
       
    }

    public void EndLog()
    {
        print(" PointCollider sollicitationToLog : " + sollicitationToLog);
        File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);
    }
}
