using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPref : MonoBehaviour
{
    public InputField inputName;
    public Button easy;
    public Button normal;
    public Button hard;

    // Start is called before the first frame update

    public void Save()
    {
        PlayerPrefs.SetString("Name", inputName.text);
    }


}
