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
    public float Starttime;
    public List<GameObject> BusPrefabs;
    

    private Vector3 initialPos;
    private Vector3 busStop = new Vector3(70.45f, 0f, 116.66f);
    /*private Vector3 otherBusStop=new Vector3(18.33f, 0f, 105.98f);*/
    private float speed = -17f;

    // Start is called before the first frame update

    void Start()

    {
        initialPos = transform.position;
        transform.position = new Vector3(-25.9f, GetComponent<Transform>().position.y, 116.66f);
        Starttime = Time.time;
    }



    // Update is called once per frame

    void Update()

    {

        if (Time.time - Starttime > 40f)

        {

            StartCoroutine("Arrive");

        }

    }

    public IEnumerator Arrive()

    {

       // GameMaster.Instance.CurrentSequence = Sequence.BusArrival;             
        /*if (playerLane)
        {*/
        //player lane
        //pre-turn
        while (transform.position.z > 116.66f)

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

        while (transform.position.x > busStop.x)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            yield return null;
        }

        StartCoroutine("BusStop");

    }

    public IEnumerator BusStop()

    {

        // GameMaster.Instance.CurrentSequence = Sequence.BusWait;

        yield return new WaitForSeconds(7f);



        StartCoroutine("Depart");



    }



    /// <summary>

    /// Makes the bus leave the bus stop

    /// </summary>

    /// <returns> Launches <see cref="GameMaster" />'s BusDeparture sequence before the bus moves and <seealso cref="GameMaster" />'s BusDestroy sequence after it has finished moving</returns>

    /// 

    public IEnumerator Depart()

    {

        // GameMaster.Instance.CurrentSequence = Sequence.BusDeparture;



        /*if (playerLane)

        {*/

        //player lane

        while (transform.position.x > 173.4f)

        {

            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);

            yield return null;

        }

        transform.position = initialPos;



        // GameMaster.Instance.CurrentSequence = Sequence.VehicleDestory;

    }







}