using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnClick1()
    {
        SceneManager.LoadScene("Introduction_Task1");
    }
    public void OnClick2()
    {
        SceneManager.LoadScene("Introduction_Task2");
    }
    public void OnClick3()
    {
        SceneManager.LoadScene("Introduction_Task3");
    }
    public void OnClick4()
    {
        SceneManager.LoadScene("IADL_BUS");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
