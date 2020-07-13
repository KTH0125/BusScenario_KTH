using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starting_Bus : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update

    void Update()
    {
        transform.Translate(Vector3.forward * Speed*Time.deltaTime);
    }
}
