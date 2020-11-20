using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class ColliderTest : MonoBehaviour {

    private Text headScreenText;
   

    public TicketMachine2 M;
    private String StringColor;

    public string playerName;

    private string sollicitationToLog;

    // Use this for initialization
    void Start () {
        
        headScreenText = GameObject.FindGameObjectWithTag("HeadScreen").GetComponent<Text>();
        

        playerName = PlayerPrefs.GetString("name");
        sollicitationToLog = "";
    }
	
	// Update is called once per frame
	void Update () {

        

    }
    
    //void OnCollisionEnter(Collision other)
    //{
    //    StringColor = M.getTicketColorString();
    //    //Debug.Log("TriggerEnter \"" + DateTime.Now.ToString() + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " " + StringColor);
    //}
    
    //void OnCollisionStay(Collision other)
    //{
    //    StringColor = M.getTicketColorString();
    //    //Debug.Log("TriggerEnter \"" + DateTime.Now.ToString() + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " " + StringColor);
    //}
    ///*
    //void OnCollisionExit(Collision other)
    //{
    //    Debug.Log("CollisionExit \"" + DateTime.Now.ToString() + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " \"Object");
    //}*/

    //void OnTriggerEnter(Collider other)
    //{
    //    StringColor = M.getTicketColorString();
    //    sollicitationToLog += GlobalTime.globalTime + ", "+playerName+", regarde, "+ other.gameObject.name +"-"+ other.gameObject.layer + "-"+ LayerMask.LayerToName(other.gameObject.layer) + "-"+ StringColor+"\n";
    //    headScreenText.text = "Name: " + other.gameObject.name + "\nLayer: " + other.gameObject.layer + "\nMask: " + LayerMask.LayerToName(other.gameObject.layer) + "\nColor: " + StringColor;
    //    //headScreenText.text = "Name: " + other.gameObject.name + "\nLayer: " + other.gameObject.layer + "\nMask: "+ LayerMask.LayerToName(other.gameObject.layer) + "\nColor: " + StringColor;
    //    Debug.Log("TriggerEnter \"" + GlobalTime.globalTime + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " " + StringColor);
    //}
    
    //void OnTriggerStay(Collider other)
    //{
    //    StringColor = M.getTicketColorString();
    //    //headScreenText.text = "Name: " + other.gameObject.name + "\nLayer: " + other.gameObject.layer + "\nMask: " + LayerMask.LayerToName(other.gameObject.layer) + "\nColor: " + StringColor;
    //    //Debug.Log("TriggerStqy \"" + DateTime.Now.ToString() + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " " + StringColor);

    //    //Debug.Log("TriggerStay \"" + DateTime.Now.ToString() + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " \"Object");
        
    //}
    
    //void OnTriggerExit(Collider other)
    //{
    //    headScreenText.text = "";
    //    sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", ne regarde plus, " + other.gameObject.name + "-" + other.gameObject.layer + "-" + LayerMask.LayerToName(other.gameObject.layer) + "-" + StringColor + "\n";
    //    Debug.Log("TriggerExit \"" + GlobalTime.globalTime + " " + other.gameObject.name + " " + other.gameObject.layer + " " + (LayerMask.LayerToName(other.gameObject.layer)) + " \"Object");
    //}

    //public void EndLog()
    //{
    //    print(" ColliderTest sollicitationToLog : " + sollicitationToLog);
    //    File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);
    //}
    
}
