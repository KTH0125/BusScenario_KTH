using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using System.Text;



public class BusTest : MonoBehaviour

{
    public string color;
    public int number;
    public string destination;
    public string ticket;
    public float startTime;

    /*public bool playerLane;*/

    private Vector3 initialPos;
    private Vector3 busStop = new Vector3(68.663f, 2.77f, 113f);
    /*private Vector3 otherBusStop=new Vector3(18.33f, 0f, 105.98f);*/
    private float speed = 7f;

    /// <summary>
    /// Puts the bus in its initial position then starts <see cref="Bus.Arrive"/>
    /// </summary>
    public void Initialize(/*isInPlayeLane*/)
    {
        initialPos = transform.position;
        /*playerLane = isInPlayerLane;*/

        /*if (playerLane)
          {*/
        transform.position = new Vector3(-38.9f, GetComponent<Transform>().position.y, 183.1f);
        //transform.eulerAngles = new Vector3(0f, 180f, 0f);
        /*}
        //else
        //{
        //    transform.position = new Vector3(-187.93f, GetComponent<Transform>().position.y, 110.14f);
        //    transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }*/

        StartCoroutine("Arrive");
    }

    public void Start()
    {

    }

    void Update()
    {

    }


    /// <summary>
    /// Makes the bus move towards its bus stop
    /// </summary>
    /// <returns>Lanches <see cref="GamemasterTest" />'s BusArrival sequence before moving the bus, then starts <see cref="BusTest.BusStop"/></returns>
    public IEnumerator Arrive()
    {
        GamemasterTest.Instance.CurrentSequence = Sequence1.BusArrival;

        /*if (playerLane)
        {*/
        //player lane
        //pre-turn
        /*while (transform.position.z > 115.9f)
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
            yield return null;
        }
        //turn
        /*while (transform.position.x > 166.76f)
        {
            transform.RotateAround(new Vector3(166.76f, 0f, 121.7f), Vector3.up, 30 * Time.deltaTime);
            yield return null;
        }*/
        //post-turn
        while (transform.position.x <= 50.3f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);

            yield return null;
        }
        /*}
        else
        {
            //non player lane
            //pre-turn
            while (transform.position.x < otherBusStop.x)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                yield return null;
            }
            //transform.position = initialPos;
        }*/

        StartCoroutine("BusStop");

    }

    /// <summary>
    /// Makes the bus wait at the bus stop
    /// </summary>
    /// <returns>Lanches <see cref="GamemasterTest" />'s BusWait sequence before waiting 7 seconnds, then starts <see cref="BusTest.Depart"/></returns>
	public IEnumerator BusStop()
    {
        GamemasterTest.Instance.CurrentSequence = Sequence1.BusWait;
        yield return new WaitForSeconds(7f);

        StartCoroutine("Depart");

    }

    /// <summary>
    /// Makes the bus leave the bus stop
    /// </summary>
    /// <returns> Launches <see cref="GamemasterTest" />'s BusDeparture sequence before the bus moves and <seealso cref="GamemasterTest" />'s BusDestroy sequence after it has finished moving</returns>
	public IEnumerator Depart()
    {
        GamemasterTest.Instance.CurrentSequence = Sequence1.BusDeparture;

        /*if (playerLane)
        {*/
        //player lane
        while (transform.position.x < 161.1f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            yield return null;
        }
        transform.position = initialPos;
        /*}
        else
        {
            //non player lane
            //pre-turn
            while (transform.position.x < 166.76f)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World);
                yield return null;
            }
            //turn
            while (transform.position.z > 104.29f)
            {
                transform.RotateAround(new Vector3(166.76f, 0f, 104.29f), Vector3.up, 45 * Time.deltaTime);
                yield return null;
            }
            //post-turn
            while (transform.position.z > 94.36f)
            {
                transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
                yield return null;
            }
            transform.position = initialPos;
        }*/

        GamemasterTest.Instance.CurrentSequence = Sequence1.VehicleDestory;
    }



}