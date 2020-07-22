using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of a car
/// </summary>
public class CarTest : MonoBehaviour
{
    public int number;
    public bool playerLane;


    private Vector3 initialPos;
    private float speed = -17f;

    /// <summary>
    /// Puts the car in its initial position then starts <see cref="Car.Move"/>
    /// </summary>
    /// <param name="isInPlayerLane">Indicates wheter the car is in the player lane of the road</param>
    public void Initialize(bool isInPlayerLane)
    {
        initialPos = transform.position;
        playerLane = isInPlayerLane;

        if (playerLane)
        {
            transform.position = new Vector3(69.41f, GetComponent<Transform>().position.y, -7.53f);
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
        }
        else
        {
            transform.position = new Vector3(-55.6f, GetComponent<Transform>().position.y, -2.4f);
            transform.eulerAngles = new Vector3(0f, 90f, 0f);
        }

        StartCoroutine("Move");
    }

    /// <summary>
    /// Makes the car move across the whole treet
    /// </summary>
    /// <returns>Launches <see cref="GameMaster" />'s CarDestroy sequence after the car has finished moving</returns>
    public IEnumerator Move()
    {
        if (playerLane)
        {
            //player lane
            //pre-turn
           /* while (transform.position.z > 121.7f)
            {
                transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
                yield return null;
            }*/
            //turn
            while (transform.position.x > 166.76f)
            {
                transform.RotateAround(new Vector3(166.76f, 0f, 121.7f), Vector3.up, 45 * Time.deltaTime);
                yield return null;
            }
            //post-turn
            while (transform.position.x > -187.93f)
            {
                transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
                yield return null;
            }
            transform.position = initialPos;
        }
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
        }

        GamemasterTest.Instance.CurrentSequence = Sequence1.VehicleDestory;

    }

}
