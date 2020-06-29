using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBus : MonoBehaviour
{
    public float Speed;
    private Vector3 initialPos;
    private Vector3 busStop = new Vector3(70.45f, 0f, 116.66f);
    private float speed = 1f;
    public float Starttime;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        Starttime = Time.time;
        transform.position = new Vector3(-38.9f, GetComponent<Transform>().position.y, 165f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        //StartCoroutine("Arrive");

        if (transform.position.x == busStop.x)
        {
            transform.Translate(Vector3.forward * 0);
        }
        else if (Time.time - Starttime > 40f)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
    }

}
    
 

