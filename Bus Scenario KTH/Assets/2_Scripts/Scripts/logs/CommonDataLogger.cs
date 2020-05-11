//Saves an instanteneous log of data containing information such as the current altitude, the number of falls, the framerate, etc.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;
using System.Net.Sockets;


public class CommonDataLogger : MonoBehaviour
{

    

    
    


    private string pathCamera;
    private string pName;
    private string new_line;

    private string pathControllers;
    private string newLineControllers;

    private string pathBusses;
    private string newLineBusses;

    private string pathCars;
    private string newLineCars;





    string LocalPosition_to_string(GameObject _gameObject)
    {
        string result = "(";
        float _x = _gameObject.transform.localPosition.x;
        float _y = _gameObject.transform.localPosition.y;
        float _z = _gameObject.transform.localPosition.z;

        result += _x;
        result += ",";
        result += _y;
        result += ",";
        result += _z;
        result += ")";

        return result;
    }

    string LocalRotation_to_string(GameObject _gameObject)
    {
        string result = "(";
        float _x = _gameObject.transform.localRotation.x;
        float _y = _gameObject.transform.localRotation.y;
        float _z = _gameObject.transform.localRotation.z;
        float _w = _gameObject.transform.localRotation.w;

        result += _x;
        result += ",";
        result += _y;
        result += ",";
        result += _z;
        result += ",";
        result += _w;
        result += ")";

        return result;
    }


    string Position_to_string(GameObject _gameObject)
    {
        string result = "(";
        float _x = _gameObject.transform.position.x;
        float _y = _gameObject.transform.position.y;
        float _z = _gameObject.transform.position.z;

        result += _x;
        result += ",";
        result += _y;
        result += ",";
        result += _z;
        result += ")";

        return result;
    }

    string Rotation_to_string(GameObject _gameObject)
    {
        string result = "(";
        float _x = _gameObject.transform.rotation.x;
        float _y = _gameObject.transform.rotation.y;
        float _z = _gameObject.transform.rotation.z;
        float _w = _gameObject.transform.rotation.w;

        result += _x;
        result += ",";
        result += _y;
        result += ",";
        result += _z;
        result += ",";
        result += _w;
        result += ")";

        return result;
    }

    // Use this for initialization
    void Start()
    {
        
        pName = PlayerPrefs.GetString("name");
        pathCamera = ApplicationModel.startDate +"-"+pName+ "-Camera_local_position_rotation_FPS"+ ".csv";
        new_line = "Timestamp;HMDPos;HMDRot;FPS;\n";

        pathControllers = ApplicationModel.startDate + "-" + pName + "-ControlleursPosition" + ".csv";
        newLineControllers = "Temps;PosGauche;RotGauche;PosDroit;RotDroit;\n";

        pathBusses = ApplicationModel.startDate + "-" + pName + "-BusPosition" + ".csv";
        newLineBusses = "Temps;PosBus1;RotBus1;PosBus2;RotBus2;PosBus3;RotBus3;PosBus4;RotBus4;PosBus5;RotBus5;PosBus6;RotBus6;PosBus7;RotBus7;PosBus8;RotBus8;\n";

        pathCars = ApplicationModel.startDate + "-" + pName + "-VoituresPosition" + ".csv";
        newLineCars = "Temps;PosVoit1;RotVoit1;PosVoit2;RotVoit2;PosVoit3;RotVoit3;PosVoit4;RotVoit4;PosVoit5;RotVoit5;PosVoit6;RotVoit6;PosVoit7;RotVoit7;PosVoit8;RotVoit8;PosVoit9;RotVoit9\n";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //new_line += GlobalTime.globalTime + ";" + LocalPosition_to_string(Camera) + ";" + LocalRotation_to_string(Camera) + ";" + 1.0f / Time.deltaTime + ";\n";
        
        //newLineControllers += GlobalTime.globalTime + ";" + Position_to_string(left) + ";" + Rotation_to_string(left) + ";" + Position_to_string(right) + ";" + Rotation_to_string(right) + "\n";

        /*newLineBusses += GlobalTime.globalTime + ";";
        newLineCars += GlobalTime.globalTime + ";";

        foreach (GameObject bus in BusPrefabs)
        {
            newLineBusses += Position_to_string(bus) + ";" + Rotation_to_string(bus) + ";";
        }
        newLineBusses += "\n";
        
        foreach (GameObject car in CarPrefabs)
        {
            newLineCars += Position_to_string(car) + ";" + Rotation_to_string(car) + ";";
        }
        newLineCars += "\n";*/
    }

    public void EndLog() {
        //File.AppendAllText(pathCamera, new_line, Encoding.UTF8);
        //File.AppendAllText(pathControllers, newLineControllers, Encoding.UTF8);
        //File.AppendAllText(pathBusses, newLineBusses, Encoding.UTF8);
        //File.AppendAllText(pathCars, newLineCars, Encoding.UTF8);
    }
}

