using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;


//Last version !!!!

/// <summary>
/// Lists all the sequences of the game
/// </summary>
public enum Sequence1
{
    VehicleInitialize = 0, BusArrival, BusWait, BusDeparture, VehicleDestory, CarDestory
}

/// <summary>
/// Lists all the states of the game
/// </summary>
public enum State1
{
    Initialize = 0, Memorize, Bus, Save
}

public enum Level
{
    Easy = 0, Normal, Hard
}

/// <summary>
/// Script that manages the state of the game
/// </summary>
public class GamemasterTest : MonoBehaviour
{

    public static GamemasterTest Instance
    {
        get { return instance; }
    }
    private static GamemasterTest instance = null;


    public string playerName;
    //public Transform head;

    public float startTime;

    public GameObject target;

    public GameObject correctObj;
    public GameObject incorrectObj1;
    public GameObject incorrectObj2;
    public GameObject incorrectObj3;
    public GameObject navigation;
    public GameObject answerShow;
    public List<GameObject> BusPrefabs;
    public List<GameObject> CarPrefabs;
    //public List<GameObject> MovableObjects;

    public GameObject cameraPlayer;
    public GameObject left, right;

    public GameObject Monitor;
    private string Zone;


    /// <summary>
    /// Manages the states of the game
    /// </summary>
	public State1 CurrentState
    {
        get
        {
            return _currentState;
        }
        set
        {
            _currentState = value;
            switch (_currentState)
            {
                case State1.Initialize:
                    CurrentState = State1.Memorize;
                    break;

                case State1.Memorize:
                    // Displays the target bus on the monitor
                    Monitor.SetActive(true);
                    Zone = "Zone2";
                    string color = targetBus.color;
                    int busNum = targetBus.number;
                    string destination = targetBus.destination;
                    string ticket = targetBus.ticket;
                    Monitor.GetComponentInChildren<TextMeshProUGUI>().text = "[Souvenez-vous de votre bus]\nCouleur: " + color + "\nNuméro: " + busNum + "\nDestination: " + destination + "\n" + ticket + "\nLe bus arrive dans 3 minutes.";
                    Debug.Log("[Votre bus]\nCouleur: " + color + "\nNuméro: " + busNum + "\nDestination: " + destination + "\n" + ticket);
                    break;

                case State1.Bus:
                    // Launches the VehicleInitialize sequence
                    Monitor.SetActive(true);
                    CurrentSequence = Sequence1.VehicleInitialize;

                    break;


                case State1.Save:
                    // Saves and ends the registering of the logs
                    Debug.Log("Current state: Save");
                    logEnded = true;
                    oneTime3 = true;
                    SaveAllLogs();
                    break;

            }
        }
    }

    private bool busHasStoppedOnce = false;
    private bool busHasGoneOnce = false;
    private BusTest currentBus;
    private string sollicitationToLog;
    private int InCorrectType;


    public TicketMachine2 ticketMachine;

    /// <summary>
    /// Manages the sequences of the game
    /// </summary>
    public Sequence1 CurrentSequence
    {
        get
        {
            return _currentSequence;
        }
        set
        {
            _currentSequence = value;
            switch (_currentSequence)
            {
                case Sequence1.VehicleInitialize:
                    userSelect = false;
                   
                    if (Time.time - startTime < 60f)
                    {
                        // Before 60 seconds, only cars and busses other than the target bus

                        currentBus = BusPrefabs[rangeOtherBuses[Random.Range(0, 2)]].GetComponent<BusTest>();
                        currentBus.Initialize();

                        /*if (Random.Range(0, 2) == 0)
                        {
                            currentBus = BusPrefabs[rangeOtherBuses[Random.Range(0, 2)]].GetComponent<BusTest>();
                            currentBus.Initialize();
                        }
                        else
                        {
                            currentBus = null;
                            CarPrefabs[Random.Range(0, 9)].GetComponent<CarTest>().Initialize();
                        }*/

                    }
                    else if (!busHasGoneOnce)
                    {
                        // After 60 seconds, target bus passes through once
                        currentBus = targetBus;
                        currentBus.Initialize();
                        busHasGoneOnce = true;
                    }
                    else
                    {
                        // After the target bus has passed through once, all vehicles
                        busHasStoppedOnce = true;

                        currentBus = BusPrefabs[rangeOtherBuses[Random.Range(0, 2)]].GetComponent<BusTest>();
                        print("GameMaster currentBus " + currentBus.name);

                        /*if (Random.Range(0, 2) == 0)
                        {
                            currentBus = BusPrefabs[rangeOtherBuses[Random.Range(0, 2)]].GetComponent<BusTest>();
                            print("GameMaster currentBus " + currentBus.name);
                            //no bus comming after target bus
                            //currentBus.Initialize(); 
                        }
                        else
                        {
                            CarPrefabs[Random.Range(0,8)].GetComponent<CarTest>().Initialize();
                        }*/
                    }

                    break;

                case Sequence1.BusArrival:
                    navigation.SetActive(false);
                    sollicitationToLog += GlobalTime.globalTime + ", Bus N° " + currentBus.number + ", entrain d'arriver devant, Arrêt de bus\n";
                    break;

                case Sequence1.BusWait:
                    sollicitationToLog += GlobalTime.globalTime + ", Bus N° " + currentBus.number + ", s'arrête devant, Arrêt de bus\n";
                    break;

                case Sequence1.BusDeparture:

                    sollicitationToLog += GlobalTime.globalTime + ", Bus N° " + currentBus.number + ", s'éloigne de, Arrêt de bus\n";
                    bool correct = false;
                    // Target bus, user took it
                    if (userSelect && currentBus.number == targetBus.number && (ticketMachine.getTicketColorString().Equals(targetBus.ticket)) && (ticketMachine.getTicketZoneString().Equals(Zone))) // => TicketZoneString 추가 , Destination Zone 추가
                    {
                        correct = true;
                        playerResultsData += GlobalTime.globalTime + "," + currentBus.number + "," + currentBus.color + "," + currentBus.destination + "," + currentBus.ticket + "," + targetBus.number + "," + targetBus.color + "," + targetBus.destination + "," + targetBus.ticket + ",Yes,\n";
                        Debug.Log("[CORRECT: bon bus, utilisateur l'a pris]");
                        print("GameMaster Ticket + bus correct : " + ticketMachine.getTicketColorString().Equals(targetBus.ticket));
                    }

                    //InCorrectType : RB,WT = 0 / WB,RT = 1 / WB,WT = 2
                    //Right bus wrong ticket
                    else if (userSelect && currentBus.number == targetBus.number && !(ticketMachine.getTicketColorString().Equals(targetBus.ticket)) || !(ticketMachine.getTicketZoneString().Equals(Zone))) // => TicketZoneString 추가 , Destination Zone 추가
                    {
                        correct = false;
                        InCorrectType = 0;
                        playerResultsData += GlobalTime.globalTime + "," + currentBus.number + "," + currentBus.color + "," + currentBus.destination + "," + currentBus.ticket + "," + targetBus.number + "," + targetBus.color + "," + targetBus.destination + "," + targetBus.ticket + ",No,\n";
                        Debug.Log("[OMISSION: bon bus mais mauvais ticket, utilisateur l'a pris]");
                        print("GameMaster Mauvais ticket + bus correct : " + ticketMachine.getTicketColorString().Equals(targetBus.ticket));
                    }

                    // Wrong bus, user did not take it
                    /*else if (!userSelect && currentBus.number != targetBus.number)
                    {
                        correct = true;
                        playerResultsData += GlobalTime.globalTime + "," + currentBus.number + "," + currentBus.color + "," + currentBus.destination + "," + currentBus.ticket + "," + targetBus.number + "," + targetBus.color + "," + targetBus.destination + "," + targetBus.ticket + ",Yes,\n";
                        Debug.Log("[CORRECT: mauvais bus, utilisateur ne l'a pas pris]");
                    }
                    // Target bus, user did not take it
                    else if (!userSelect && currentBus.number == targetBus.number)
                    {
                        correct = false;
                        playerResultsData += GlobalTime.globalTime + "," + currentBus.number + "," + currentBus.color + "," + currentBus.destination + "," + currentBus.ticket + "," + targetBus.number + "," + targetBus.color + "," + targetBus.destination + "," + targetBus.ticket + ",No,\n";
                        Debug.Log("[OMMISSION: bon bus, utilisateur ne l'a pas pris]");
                    }*/

                    //  Wrong bus, Right ticket, user took it
                    else if (userSelect && currentBus.number != targetBus.number)
                    {
                        correct = false;
                        InCorrectType = 1;
                        playerResultsData += GlobalTime.globalTime + "," + currentBus.number + "," + currentBus.color + "," + currentBus.destination + "," + currentBus.ticket + "," + targetBus.number + "," + targetBus.color + "," + targetBus.destination + "," + targetBus.ticket + ",No,\n";
                        Debug.Log("[OMMISSION: mauvais bus, utilisateur l'a pris]");
                    }

                    else if (userSelect && currentBus.number != targetBus.number && !(ticketMachine.getTicketColorString().Equals(targetBus.ticket)) || !(ticketMachine.getTicketZoneString().Equals(Zone)))
                    {
                        correct = false;
                        InCorrectType = 2;
                    }

                    StartCoroutine("ProblemFeedback", correct);
                    break;

                case Sequence1.VehicleDestory:
                    // Initializes a new vehicle
                    GamemasterTest.Instance.CurrentSequence = Sequence1.VehicleInitialize;
                    break;

            }
        }
    }

    //0:normal 2:target
    public int userState = 0;

    private int targetBusNumber;
    private int[] rangeOtherBuses;

    private BusTest targetBus;

    private Sequence1 _currentSequence;
    private State1 _currentState;

    //private static string pathPositionAngle;
    private static string pathPlayerResults;

    //private string positionAngleData;
    private string playerResultsData;

    //public ControllerHitGrabObject controllerHitGrabObject;
    public ColliderTest colliderTest;
    //public CommonDataLogger commonDataLogger;


    // Use this for initialization
    /// <summary>
    /// Initialization method
    /// </summary>
    void Start()
    {


        playerName = PlayerPrefs.GetString("name");

        // Initializing the log files
        string date = System.DateTime.Now.ToString("yyyy_MM_dd_");


        //pathPositionAngle = date + playerName + "_Player_position_angle.csv";
        pathPlayerResults = "Logs/" + date + playerName + "_player_resulats.csv";


        //positionAngleData = "time, posX, posY, posZ, angX, angY, angZ,\n";
        playerResultsData = "time, current bus number, current bus color, current bus destination, current bus ticket, target bus number, target bus color, target bus destination, target bus ticket, correct answer,\n";

        startTime = Time.time;

        sollicitationToLog = "";

        // Seclection of the target bus
        //targetBusNumber = Random.Range(0, 3);
        targetBusNumber = 2;
        Debug.Log("[RIGHT BUS: " + targetBusNumber + "]");

        targetBus = BusPrefabs[targetBusNumber].GetComponent<BusTest>();

        // List of the other busses
        rangeOtherBuses = new int[3];
        int count = 0;
        for (int busNum = 0; busNum <= 3; busNum++)
        {
            if (busNum != targetBusNumber)
            {
                rangeOtherBuses[count] = busNum;
                Debug.Log("[OTHER BUSES nb" + count + ": " + rangeOtherBuses[count] + "]");
                count += 1;
            }
        }
        Debug.Log("[OTHER BUSES LENGTH: " + rangeOtherBuses.Length + "]");

        CurrentState = State1.Initialize;
    }

    void Awake()
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    bool logEnded = false;
    bool oneTime1 = false;
    bool oneTime2 = false;
    bool oneTime3 = false;

    bool estDeboutTargetPoint = false;

    /// <summary>
    /// Update function
    /// </summary>
    void FixedUpdate()
    {

        CheckSelect();

        if (CurrentSequence == Sequence1.BusArrival || CurrentSequence == Sequence1.BusWait || CurrentSequence == Sequence1.BusDeparture)
        {
            if (!userSelect && userState == 2)
            {
                userSelect = true;
            }
        }
        if (CurrentState == State1.Memorize)
        {
            CurrentState = State1.Bus;

        }

        string color = targetBus.color;
        int busNum = targetBus.number;
        string destination = targetBus.destination;
        string ticket = targetBus.ticket;

        if (Time.time - startTime > 30f && !oneTime1)
        {
            Monitor.GetComponentInChildren<TextMeshProUGUI>().text = "";
            oneTime1 = true;
        }

        if (Time.time - startTime > 60f && !oneTime2 && busHasStoppedOnce)
        {
            Monitor.GetComponentInChildren<TextMeshProUGUI>().text = "[Votre bus]\nCouleur: " + color + "\nNuméro: " + busNum + "\nDestination: " + destination + "\n" + ticket + "\nLe bus est passé.";
            oneTime2 = true;
        }

        if (!logEnded)
        {
            //WriteObjectLog();
        }

        if (!oneTime3)
        {
            if (busHasStoppedOnce && !logEnded)
            {
                print("GameMaster enter state save (begin save logs)");
                CurrentState = State1.Save;
            }
        }

    }

    /// <summary>
    /// Gives visual and audio feedback about the bus which has passed through
    /// </summary>
    /// <param name="correct">Result of the bus passing through</param>
    /// <returns>Returns visual and audio feedback</returns>
	IEnumerator ProblemFeedback(bool correct)
    {
        GameObject tmp;
        if (correct)
        {
            tmp = correctObj;
        }
        else
        {

            tmp = incorrectObj1;
/*            if(!correct && InCorrectType == 0)
            {
                tmp = incorrectObj1;
            }
            else if (!correct && InCorrectType == 1)
            {
                tmp = incorrectObj2;
            }
            else if (!correct && InCorrectType == 2)
            {
                tmp = incorrectObj3;
            }*/

        }
        tmp.SetActive(true);
        tmp.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.5f);
        tmp.SetActive(false);
        if (CurrentSequence == Sequence1.VehicleInitialize)
            navigation.SetActive(true);

    }

    //data
    private bool userSelect = false;

    /// <summary>
    /// Stops the registering in text files
    /// </summary>
    void SaveAllLogs()
    {

        //Loges movable objects, cars, busses position and rotation
       /* foreach (GameObject movableObject in MovableObjects)
        {
            if (movableObject.activeSelf)
                movableObject.GetComponent<MovableObjectLog>().EndLog();
        }*/

        foreach (GameObject carObject in CarPrefabs)
        {
            if (carObject.activeSelf)
                carObject.GetComponent<VehiculeLog>().EndLog();
        }

        foreach (GameObject busObject in BusPrefabs)
        {
            if (busObject.activeSelf)
                busObject.GetComponent<VehiculeLog>().EndLog();
        }

        //Logs camera and controllers position and rotation
        cameraPlayer.GetComponent<DeviceLog>().EndLog();
        left.GetComponent<DeviceLog>().EndLog();
        right.GetComponent<DeviceLog>().EndLog();

        //File.AppendAllText(pathPositionAngle, positionAngleData, Encoding.UTF8);
        File.AppendAllText(pathPlayerResults, playerResultsData, Encoding.UTF8);

        //Logs actions related to the vending Machine
        //ticketMachine.EndLog();

        //Logs all objects that were grabbed
        // controllerHitGrabObject.EndLog();

        //Logs all objects entered or exited by the collider
        //colliderTest.EndLog();

        //commonDataLogger.EndLog();
        //Logs bus behavior and if player steps or not on target point
        File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);




        Debug.Log("[Fin Logs objets]");
    }

    /// <summary>
    /// Writes information about objects in text files
    /// </summary>
    void WriteObjectLog()
    {
        /*foreach (GameObject movableObject in MovableObjects)
        {
            if (movableObject.activeSelf)
                movableObject.GetComponentInChildren<MovableObjectLog>().WriteLog(GlobalTime.globalTime);
        }*/
        //player's head position and rotation

        //positionAngleData += GlobalTime.globalTime + "," + head.transform.position.x + "," + head.transform.position.y + "," + head.transform.position.z + "," + head.transform.eulerAngles.x + "," + head.transform.eulerAngles.y + "," + head.transform.eulerAngles.z + ",\n";

    }

    /// <summary>
    /// Checks if the user is selecting a bus
    /// </summary>
    void CheckSelect()
    {
        if (Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.z), new Vector2(cameraPlayer.transform.position.x, cameraPlayer.transform.position.z)) <= 0.414f)
        {
            userState = 2;
            if (estDeboutTargetPoint == false)
                sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", est debout sur, Target Point\n";
            estDeboutTargetPoint = true;
        }
        else
        {
            userState = 0;
            if (estDeboutTargetPoint == true)
                sollicitationToLog += GlobalTime.globalTime + " " + playerName + ", n'est plus debout sur, Target Point\n";
            estDeboutTargetPoint = false;
        }
    }


}
