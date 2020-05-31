using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class ControllerHitGrabObject : MonoBehaviour
{

    private SteamVR_TrackedObject trackedObj;

    private GameObject collidingObject;
    private GameObject objectInHand;

    private string pathIsGrabbed;
   
    private string isGrabbed;
   
    public string playerName;

    private float startTime;

    private string sollicitationToLog;



    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();


    }

    void Start()
    {
        print("Enter ControllerHitGrabObjects");
        //startTime = Time.time;
        playerName = PlayerPrefs.GetString("name"); ;
        string date = System.DateTime.Now.ToString("yyyy_MM_dd_");
        pathIsGrabbed = date + playerName + "_" + gameObject.name + "_pris_log.csv";
        print("pathIsGrabbed : " + pathIsGrabbed);
        isGrabbed = "temps, estPris/estRelaché,\n";

        sollicitationToLog = "";
    }

    //set which controller is colliding
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    //Trigger methods
    //set collider on trigger event
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    //set collider on stay (hold event)
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    //set collidingObject to null on trigger release
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }

    //grab object function
    private void GrabObject()
    {
        
        //set collidingObject reference to objectInHand
        objectInHand = collidingObject;
        collidingObject = null;
        //add a fixed joint
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();

        //log grabbed object
        isGrabbed += GlobalTime.globalTime + ", prend " + objectInHand.name + "\n";
        sollicitationToLog += GlobalTime.globalTime + ", "+playerName+", prend, "+ objectInHand.name+"\n";
    }

    //add fixed joint function
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    //release function
    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            //release fixed joint memory if defined
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
            isGrabbed += GlobalTime.globalTime + ", relâche " + objectInHand.name + "\n";
            sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", relâche, " + objectInHand.name + "\n";
        }
        //set objectInHand to null
        objectInHand = null;
    }

    public void EndLog()
    {
        if (pathIsGrabbed != null)
        {
            print("ControllerHitGrabObject isGrabbed : " + isGrabbed);
            File.AppendAllText(pathIsGrabbed, isGrabbed, Encoding.UTF8);
        }
        print("ControllerHitGrabObject sollicitationToLog : " + sollicitationToLog);
        File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);
    }

    // Update is called once per frame
    void Update()
    {
        //grab object if trigger is pressed and colliding object is defined
        if (Controller.GetHairTriggerDown())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }
        //release objects (fixed joint and objectInHand) when trigger is released
        if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
