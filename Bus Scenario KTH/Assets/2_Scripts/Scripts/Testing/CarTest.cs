using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the behavior of a car
/// </summary>
public class CarTest : MonoBehaviour
{
    public int number;


    private Vector3 initialPos;
    private float speed = -17f;

    /// <summary>
    /// Puts the car in its initial position then starts <see cref="Car.Move"/>
    /// </summary>
    /// <param name="isInPlayerLane">Indicates wheter the car is in the player lane of the road</param>
    public void Initialize()
    {
        initialPos = transform.position;
        transform.position = new Vector3(69.3f, GetComponent<Transform>().position.y, -7.8f);
        transform.eulerAngles = new Vector3(0f, -90f, 0f);

        StartCoroutine("Move");
    }

    /// <summary>
    /// Makes the car move across the whole treet
    /// </summary>
    /// <returns>Launches <see cref="GameMaster" />'s CarDestroy sequence after the car has finished moving</returns>
    public IEnumerator Move()
    {
        while (transform.position.x <= -63.4f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);

            yield return null;
        }

        GamemasterTest.Instance.CurrentSequence = Sequence1.VehicleDestory;

    }

}
