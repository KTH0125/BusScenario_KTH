using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class GlobalTime : MonoBehaviour {
    public static float globalTime = 0.0f;
    private Text sceneGlobaltime;

    void Update () {
        globalTime += Time.deltaTime;
        sceneGlobaltime.text = "" + GlobalTime.globalTime;
    }

    private void Start()
    {
        sceneGlobaltime = GameObject.FindGameObjectWithTag("GlobalTime").GetComponent<Text>();
    }
}
