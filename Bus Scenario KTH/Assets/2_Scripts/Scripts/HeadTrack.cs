using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class HeadTrack : MonoBehaviour {

    public string playerName;
    private string sollicitationToLog;

    // Use this for initialization
    void Start () {
        playerName = PlayerPrefs.GetString("name");
        sollicitationToLog = "";

        print("HEADTRACK!!!!!!!!!!!!!!!!!!!!!!!!!");

    }
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){
		if(other.tag=="InitialPoint"){
				GameMaster.Instance.userState=1;
                sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", est debout sur, Initial Point\n";
        }
		if(other.tag=="TargetPoint"){
				GameMaster.Instance.userState=2;
                sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", est debout sur, Target Point\n";
        }
	}
	void OnTriggerExit(Collider other){
        if (other.tag == "InitialPoint")
        {
            GameMaster.Instance.userState = 0;
            sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", n'est plus debout sur, Initial Point\n";
        }
        if(other.tag=="TargetPoint"){
			GameMaster.Instance.userState=0;
            sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", n'est plus debout sur, Target Point\n";
        }
	}

    public void EndLog()
    {
        print(" ColliderTest sollicitationToLog : " + sollicitationToLog);
        File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);
    }
}
