using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class InitializeInfo : MonoBehaviour {
	
	public TMP_InputField playerName;
	// Use this for initialization
	void Start () {
        
        this.GetComponent<Button>().onClick.AddListener(SceneChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   /* private void On()
    {
        print("OnMouseDown");
        SceneChange();
    }*/

    private void SceneChange(/*int level*/){
        print("OnClick");
        if (playerName.text==null|| playerName.text=="")
			return;
        print("text :" + playerName.text);
		PlayerPrefs.SetString("name", playerName.text);
		SceneManager.LoadScene("IADL_BUS");
	}
}
