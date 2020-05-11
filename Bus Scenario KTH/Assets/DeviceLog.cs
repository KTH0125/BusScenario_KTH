using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DeviceLog : MonoBehaviour
{


    public string playerName;


    private string pathPositionAngleObject;

    private string positionAngleObjectData;

    // Use this for initialization
    void Start()
    {
        playerName = PlayerPrefs.GetString("name");


        string date = System.DateTime.Now.ToString("yyyy_MM_dd_");
        pathPositionAngleObject = "Logs/" + date + playerName + "_" + gameObject.name + "_positionAngle_log.csv";
        //write path name of position and rotation file in a common file
        //File.AppendAllText("Logs/ReplayLogsList.txt", pathPositionAngleObject + "\n", Encoding.UTF8);
        print("pathPositionAngleObject : " + pathPositionAngleObject);
        positionAngleObjectData = "time, posX, posY, posZ, angX, angY, angZ,\n";



    }

    // Update is called once per frame
    void Update()
    {
        positionAngleObjectData += GlobalTime.globalTime + "," + transform.position.x + "," + transform.position.y + "," + transform.position.z + "," + transform.eulerAngles.x + "," + transform.eulerAngles.y + "," + transform.eulerAngles.z + ",\n";
    }

    public void WriteLog(float time)
    {


        /*swPos.WriteLine(time + "," + transform.position.x + "," + transform.position.y + "," + transform.position.z + ",");
        //Debug.Log("position objet: "+time + ", " + transform.position.x + ", " + transform.position.y + ", " + transform.position.z + ", ");

        swAngle.WriteLine(time + "," + transform.eulerAngles.x + "," + transform.eulerAngles.y + "," + transform.eulerAngles.z + ",");

        swGrabbed.WriteLine(time + "," + gameObject + ",");*/

    }

    public void EndLog()
    {
        File.AppendAllText(pathPositionAngleObject, positionAngleObjectData, Encoding.UTF8);
    }
}


