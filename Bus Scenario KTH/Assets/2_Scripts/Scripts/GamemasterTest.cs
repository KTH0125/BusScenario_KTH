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
        if (Time.time - startTime < 60f)
        {
            // Before 60 seconds, only cars and busses other than the target bus
            if (Random.Range(0, 2) == 0)
            {
                currentBus = BusPrefabs[rangeOtherBuses[Random.Range(0, 7)]].GetComponent<BusTest>();
            }
            else
            {
                currentBus = null;
                CarPrefabs[Random.Range(0, 9)].GetComponent<Car>().Initialize((Random.Range(0, 2) == 1));
            }

        }
            else
            {
                CarPrefabs[Random.Range(0, 8)].GetComponent<Car>().Initialize((Random.Range(0, 2) == 1));
            }
        }
    }

    // Update is called once per frame
