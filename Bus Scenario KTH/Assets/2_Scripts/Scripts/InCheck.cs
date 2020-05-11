using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System; 

public class InCheck : MonoBehaviour {

    ///private Text text;

    void Awake()
    {
        //text = GameObject.Find("Text").GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //text.text = "IN";
        //Debug.Log(DateTime.Now.ToString() + " IN");
        //text.color = Color.red;
    }

    void OnTriggerExit(Collider other)
    {
        //text.text = "OUT";
        //Debug.Log(DateTime.Now.ToString() + " OUT");
        //text.color = Color.blue;
    }
}
