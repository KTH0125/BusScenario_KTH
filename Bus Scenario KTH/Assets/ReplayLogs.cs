using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEditor;

public class ReplayLogs : MonoBehaviour {


    private List<string> paths;


    // Use this for initialization
    void Start () {

        //desactivate for replay Mode
        //gamemaster
        //VehiculeLog
        //DeviceLog
        //MovableObjetLog

        paths = new List<string>();
        //ReadPathAtPosition(0);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadPathAtPosition(int index) {
        //paths.Add(path);
        string path = " ";
        if (File.Exists("Logs/ReplayLogsList.txt")) { 
            using (StreamReader srPath = File.OpenText("Logs/ReplayLogsList.txt"))
            {

                while (!srPath.EndOfStream)
                {
                    path = srPath.ReadLine();
                    print("path : " + path);
                }
            }
        }
    }


    public void Read_RawdataFile(string path_UserRawData_file)
    {
        string line = " ";
        using (StreamReader sr = File.OpenText(path_UserRawData_file))
        {
            while (!sr.EndOfStream)
            {
                if (line[0] == 'M')
                {
                    line = sr.ReadLine();
                    /*string[] Mesh_info = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                    mesh_name[count] = Mesh_info[0];
                    mesh_scale[count] = StringToVector3(Mesh_info[1]);*/
                }
                else if (line[0] == 'C')
                {
                   /* sr.ReadLine();
                    line = sr.ReadLine();//start the recuperation of the raw data for this mesh
                    while (sr.Peek() != -1 && line[0] != 'M')
                    {
                        string[] RawData_Oneframe = line.Split(Separators, StringSplitOptions.RemoveEmptyEntries);
                        int frame_nb = int.Parse(RawData_Oneframe[0]);//print(frame_nb);
                        cam_pos[count, frame_nb] = StringToVector3(RawData_Oneframe[1]);
                        cam_rot[count, frame_nb] = StringToVector3(RawData_Oneframe[2]);
                        mesh_pos[count, frame_nb] = StringToVector3(RawData_Oneframe[3]);
                        mesh_rot[count, frame_nb] = StringToVector3(RawData_Oneframe[4]);
                        gaze_viewport[count, frame_nb] = StringToVector2(RawData_Oneframe[5]);
                        timestamp[count, frame_nb] = float.Parse(RawData_Oneframe[6]);
                        line = sr.ReadLine();
                        //Have to check if the last line is read or not !!!
                    }
                    count++;*/
                }
                else line = sr.ReadLine();
            }
            sr.Close();
        }
       /* print(cam_pos[0, 1499].x + "    " + cam_pos[0, 1499].y);
        print(cam_rot[0, 1499].x + "    " + cam_rot[0, 1499].y);
        print(mesh_pos[0, 1499].x + "    " + mesh_pos[0, 1499].y);
        print(mesh_rot[0, 1499].x + "    " + mesh_rot[0, 1499].y);
        print(gaze_viewport[0, 1499].x + "    " + gaze_viewport[0, 1499].y);
        print(timestamp[0, 1499]);
        print(timestamp[0, 1499]);*/
    }


}
