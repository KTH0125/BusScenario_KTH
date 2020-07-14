using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GamemasterTest : MonoBehaviour
{
    public float startTime;
    public List<GameObject> BusPrefabs;
    public List<GameObject> CarPrefabs;
    private BusTest currentBus;
    public int[] rangeOtherBuses;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {

    }
    public void Busstart()
    {
        if (startTime > 20f)
        {
            currentBus=BusPrefabs[0].GetComponent<BusTest>();
            currentBus.Initialize();
        }
    }
}


    // Update is called once per frame
