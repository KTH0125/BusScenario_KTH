using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

using System.Linq;
using System;
using System.Diagnostics;
//using MiddleVR_Unity3D;


public class BusControl : MonoBehaviour {
    /*
        private GameObject GO_PHONE;
        private GameObject GO_BUS;

        private GameObject HEAD_LOG;
        private GameObject LEFT_FOOT_LOG;
        private GameObject RIGHT_FOOT_LOG;

        private GameObject BUS_G16E;
        private GameObject BUS_G16S;
        private GameObject BUS_G18E;
        private GameObject BUS_G18S;
        private GameObject BUS_B16E;
        private GameObject BUS_B16S;
        private GameObject BUS_B18E;
        private GameObject BUS_B18S;

        private Texture PHONE_G16E;
        private Texture PHONE_G16S;
        private Texture PHONE_G18E;
        private Texture PHONE_G18S;
        private Texture PHONE_B16E;
        private Texture PHONE_B16S;
        private Texture PHONE_B18E;
        private Texture PHONE_B18S;

        private UnityEngine.Random rand = new UnityEngine.Random();
        private Vector3 start_position;

        FileStream fs;	
        StreamWriter sw;

        private int index = 0;

        private List<int> Goal = new List<int>();
        private List<List<int>> ProbSet = new List<List<int>>();

        private VRSharedValue<List<int>> ProbGoal;
        //private VRSharedValue<int> ProbSet2;
        private VRSharedValue<List<List<int>>> ProbSet3;

        RaycastHit hit;

        private string outputDataPath = "Z:\\";


        //private VRSharedValue<int> ProbSet2  = new VRSharedValue<int>("ProbSet2", 0);
        private bool BusNumCon = false;
        // 버스 탑승 여부
        public int isTake = 0;
        // 몇번째 문제인가
        public int TaskNum = 0;
        // 해당 문제에서 몇번째 버스인가
        public int BusNum = 0;
        // Number를 몇 번 응시했는가
        public int NumberCounted = 0;
        // Destination를 몇 번 응시했는가
        public int DestinationCounted = 0;
        // Color를 몇 번 응시했는가
        public int ColorCounted = 0;

        // 버스 접근하는 동안 collider 제거; 버스 멈춘동안 collider 생성
        private GameObject ArrivalCollider;

        // 데이터 출력을 위한 코드
        ArrayList indexList = new ArrayList();
        ArrayList TaskNumList = new ArrayList();
        ArrayList BusNumList = new ArrayList();	
        ArrayList ProbSetList = new ArrayList();	
        ArrayList isTakeList = new ArrayList();	
        ArrayList TotalTimerList = new ArrayList();
        ArrayList TaskTimerList = new ArrayList();
        ArrayList HeadLogXList = new ArrayList();
        ArrayList HeadLogYList = new ArrayList();
        ArrayList HeadLogZList = new ArrayList();
        ArrayList HeadLogXRotate = new ArrayList();
        ArrayList HeadLogYRotate = new ArrayList();
        ArrayList HeadLogZRotate = new ArrayList();
        ArrayList LeftFootLogX = new ArrayList();
        ArrayList LeftFootLogY = new ArrayList();
        ArrayList LeftFootLogZ = new ArrayList();
        ArrayList RightFootLogX = new ArrayList();
        ArrayList RightFootLogY = new ArrayList();
        ArrayList RightFootLogZ = new ArrayList();
        ArrayList NumberCount = new ArrayList();
        ArrayList DestinationCount = new ArrayList();
        ArrayList ColorCount = new ArrayList();

        // 데이터 출력을 위한 기존 코드 
        /**
        private List<string> indexList = new List<string>();
        private List<string> TaskNumList = new List<string>();
        private List<string> BusNumList = new List<string>();
        private List<string> ProbSetList = new List<string>();
        private List<string> isTakeList = new List<string>();
        private List<string> TotalTimerList = new List<string>();
        private List<string> TaskTimerList = new List<string>();
        private List<string> HeadLogXList = new List<string>();
        private List<string> HeadLogYList = new List<string>();
        private List<string> HeadLogZList = new List<string>();
        //private List<string> HeadLogXRotateList = new List<string>();
        //private List<string> HeadLogYRotateList = new List<string>();
        //private List<string> HeadLogZRotateList = new List<string>();

    ////////////////////////////////////////////////////////////////
        private Stopwatch TotalTimer = new Stopwatch();
        private Stopwatch TaskTimer = new Stopwatch();
        private Stopwatch BusStopTimer = new Stopwatch();

        public enum BUS { Ready, Arrival, Stop, Depart, Finish }
        public BUS BusState = BUS.Ready;

        //private bool isServer = false;


        void Start()
        {
            GO_BUS = new GameObject();
            GO_PHONE = GameObject.Find("PHONE");

            BUS_G16E = GameObject.Find("G16E");
            BUS_G16S = GameObject.Find("G16S");
            BUS_G18E = GameObject.Find("G18E");
            BUS_G18S = GameObject.Find("G18S");
            BUS_B16E = GameObject.Find("B16E");
            BUS_B16S = GameObject.Find("B16S");
            BUS_B18E = GameObject.Find("B18E");
            BUS_B18S = GameObject.Find("B18S");

            ArrivalCollider = GameObject.Find ("Cube");

            BUS_G16E.SetActive(false);
            BUS_G16S.SetActive(false);
            BUS_G18E.SetActive(false);
            BUS_G18S.SetActive(false);
            BUS_B16E.SetActive(false);
            BUS_B16S.SetActive(false);
            BUS_B18E.SetActive(false);
            BUS_B18S.SetActive(false);

            PHONE_G16E = Resources.Load("Textures/PHONE_G16E") as Texture;
            PHONE_G16S = Resources.Load("Textures/PHONE_G16S") as Texture;
            PHONE_G18E = Resources.Load("Textures/PHONE_G18E") as Texture;
            PHONE_G18S = Resources.Load("Textures/PHONE_G18S") as Texture;
            PHONE_B16E = Resources.Load("Textures/PHONE_B16E") as Texture;
            PHONE_B16S = Resources.Load("Textures/PHONE_B16S") as Texture;
            PHONE_B18E = Resources.Load("Textures/PHONE_B18E") as Texture;
            PHONE_B18S = Resources.Load("Textures/PHONE_B18S") as Texture;

            HEAD_LOG = GameObject.Find("HeadNode");
    //		HEAD_LOG.AddComponent ("Scripts/BusControl");
            HEAD_LOG.AddComponent<Rigidbody> ();
            SphereCollider sc = HEAD_LOG.AddComponent<SphereCollider>();
            sc.isTrigger = true;

            LEFT_FOOT_LOG = GameObject.Find("LeftFootNode");
            RIGHT_FOOT_LOG = GameObject.Find("RightFootNode");

            start_position = new Vector3(108f, 0f, 114f);
            BusState = BUS.Ready;
            GenerateProblem ();


            ProbGoal = new VRSharedValue<List<int>>("ProbGoal", new List<int>());
            ProbSet3 = new VRSharedValue<List<List<int>>>("ProbSet3", new List<List<int>>());

            if(MiddleVR.VRClusterMgr.IsServer()) 
            {
                fs = new FileStream(outputDataPath + "resultbus.csv", FileMode.Append, FileAccess.Write);
                sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            }

            ProbGoal.value = Goal;
            ProbSet3.value = ProbSet;
    //		SetPhoneTexture(Goal[TaskNum]);
            GO_PHONE.SetActive(true);

            GO_BUS.SetActive(false);
    //		SetPhoneTexture(ProbGoal.value[TaskNum]);
            SetPhoneTexture(Goal[TaskNum]);
    //		GO_PHONE.transform.position = HEAD_LOG.transform.position + new Vector3(0.5f, 0, 0);
            GO_PHONE.transform.position = new Vector3(70.3f, 3.3f, 120.4f);


            TotalTimer.Start();



        }


        /**
        void Awake()
        {
            fs = new FileStream("resultbus.csv", FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs, System.Text.Encoding.UTF8);

            GO_BUS = new GameObject();
            GO_PHONE = GameObject.Find("PHONE");
            HEAD_LOG = GameObject.Find("HeadNode");

            BUS_G16E = GameObject.Find("G16E");
            BUS_G16S = GameObject.Find("G16S");
            BUS_G18E = GameObject.Find("G18E");
            BUS_G18S = GameObject.Find("G18S");
            BUS_B16E = GameObject.Find("B16E");
            BUS_B16S = GameObject.Find("B16S");
            BUS_B18E = GameObject.Find("B18E");
            BUS_B18S = GameObject.Find("B18S");

            BUS_G16E.SetActive(false);
            BUS_G16S.SetActive(false);
            BUS_G18E.SetActive(false);
            BUS_G18S.SetActive(false);
            BUS_B16E.SetActive(false);
            BUS_B16S.SetActive(false);
            BUS_B18E.SetActive(false);
            BUS_B18S.SetActive(false);

            PHONE_G16E = Resources.Load("Textures/PHONE_G16E") as Texture;
            PHONE_G16S = Resources.Load("Textures/PHONE_G16S") as Texture;
            PHONE_G18E = Resources.Load("Textures/PHONE_G18E") as Texture;
            PHONE_G18S = Resources.Load("Textures/PHONE_G18S") as Texture;
            PHONE_B16E = Resources.Load("Textures/PHONE_B16E") as Texture;
            PHONE_B16S = Resources.Load("Textures/PHONE_B16S") as Texture;
            PHONE_B18E = Resources.Load("Textures/PHONE_B18E") as Texture;
            PHONE_B18S = Resources.Load("Textures/PHONE_B18S") as Texture;

            start_position = new Vector3(108f, 0f, 114f);
            BusState = BUS.Ready;
            GenerateProblem ();

        }



        // Use this for initialization
        void Start() 
        {
            ProbGoal = new VRSharedValue<List<int>>("ProbGoal", new List<int>());
            //ProbSet2 = new VRSharedValue<int>("ProbSet2", 0);
            ProbSet3 = new VRSharedValue<List<List<int>>>("ProbSet3", new List<List<int>>());

            ProbGoal.value = Goal;
            ProbSet3.value = ProbSet;

            //		SetPhoneTexture(Goal[TaskNum]);
            SetPhoneTexture(ProbGoal.value[TaskNum]);
            GO_PHONE.SetActive(true);
            GO_BUS.SetActive(false);

    //		fs = new FileStream("resultbus.csv", FileMode.Append, FileAccess.Write);
    //		sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            sw.WriteLine(DateTime.Today.ToString("yyyy-MM-dd"));
            sw.WriteLine("Goal" + "," + "Problem");

            for (int i = 0; i < ProbSet3.value.Count(); i++)
            {
                sw.Write(ProbGoal.value[i].ToString() + ",");

                for (int j = 0; j < ProbSet3.value[i].Count(); j++)
                {
                    sw.Write(ProbSet3.value[i][j].ToString() + ",");
                }
                sw.WriteLine();
            }

            sw.WriteLine("index" + "," + "task num" + "," + "bus num" + "," +
                           "bus condition" + "," + "selection" + "," + "time" + "," +
                             "task time" + "," + "head X" + "," + "head Y" + "," + "head Z");

            TotalTimer.Start();
        }

        **/

    // 원래 지훈이 코딩
    /**
    try{
        fs = new FileStream("result_bus.csv", FileMode.Append, FileAccess.Write);
        sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
        sw.WriteLine(DateTime.Today.ToString("yyyy-MM-dd"));
        sw.WriteLine("Goal" + "," + "Problem");
        
        //for (int i = 0; i < ProbSet.Count(); i++)
        for (int i = 0; i < ProbSet3.value.Count(); i++)
        {
            //sw.Write(Goal[i].ToString() + ",");
            sw.Write(ProbGoal.value[i].ToString() + ",");
            
            //for (int j = 0; j < ProbSet[i].Count(); j++)
            for (int j = 0; j < ProbSet3.value[i].Count(); j++)
            {
                sw.Write(ProbSet3.value[i][j].ToString() + ",");
            }
            sw.WriteLine();
        }
        
        sw.WriteLine("index" + "," + "task num" + "," + "bus num" + "," +
                     "bus condition" + "," + "selection" + "," + "time" + "," +
                     "task time" + "," + "head X" + "," + "head Y" + "," + "head Z" + 
                     "," + "head X rotate" + "," + "head Y rotate" + "," + "head Z rotate");

        sw.WriteLine("index" + "," + "task num" + "," + "bus num" + "," +
                     "bus condition" + "," + "selection" + "," + "time" + "," +
                     "task time" + "," + "head X" + "," + "head Y" + "," + "head Z");
        isServer = true;
    }catch(Exception e){
        isServer = false;		
    }

//////////////////////////////////////////////////////////////////////



void FixedUpdate()
{
    index++;

    //
//		UnityEngine.Debug.Log(HEAD_LOG.transform.eulerAngles.x.ToString() + "," + HEAD_LOG.transform.eulerAngles.y.ToString() + "," + HEAD_LOG.transform.eulerAngles.z.ToString());

    indexList.Add(index.ToString());
    TaskNumList.Add(TaskNum.ToString());
    BusNumList.Add(BusNum.ToString());
    ProbSetList.Add(ProbSet3.value[TaskNum][BusNum].ToString());
    isTakeList.Add(isTake.ToString());
    TotalTimerList.Add(TotalTimer.ElapsedMilliseconds.ToString());
    TaskTimerList.Add(TaskTimer.ElapsedMilliseconds.ToString());
    HeadLogXList.Add(HEAD_LOG.transform.localPosition.x.ToString());
    HeadLogYList.Add(HEAD_LOG.transform.localPosition.y.ToString());
    HeadLogZList.Add(HEAD_LOG.transform.localPosition.z.ToString());
    HeadLogXRotate.Add(HEAD_LOG.transform.eulerAngles.x.ToString());
    HeadLogYRotate.Add(HEAD_LOG.transform.eulerAngles.y.ToString());
    HeadLogZRotate.Add(HEAD_LOG.transform.eulerAngles.z.ToString());
    LeftFootLogX.Add(LEFT_FOOT_LOG.transform.localPosition.x.ToString());
    LeftFootLogY.Add(LEFT_FOOT_LOG.transform.localPosition.y.ToString());
    LeftFootLogZ.Add(LEFT_FOOT_LOG.transform.localPosition.z.ToString());
    RightFootLogX.Add(RIGHT_FOOT_LOG.transform.localPosition.x.ToString());
    RightFootLogY.Add(RIGHT_FOOT_LOG.transform.localPosition.y.ToString());
    RightFootLogZ.Add(RIGHT_FOOT_LOG.transform.localPosition.z.ToString());
    NumberCount.Add(NumberCounted.ToString ());
    DestinationCount.Add (DestinationCounted.ToString());
    ColorCount.Add (ColorCounted.ToString ());


    //ProbSet2.value = ProbSet[TaskNum][BusNum];

    switch (BusState)
    {
        case BUS.Ready:

            SetBusObject(ProbSet3.value[TaskNum][BusNum]);
            GO_BUS.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
            GO_BUS.transform.position = start_position;
            GO_BUS.SetActive(false);

            NumberCounted = 0;
            DestinationCounted = 0;
            ColorCounted = 0;

            if (BusNum == 0)
            {
                GO_PHONE.SetActive(true);
            }
            else
            {
                BusState = BUS.Arrival;        
            }
            break;
        case BUS.Arrival:
            GO_PHONE.SetActive(false);
            GO_BUS.SetActive(true);
            GO_BUS.GetComponent<Rigidbody>().velocity = new Vector3(-5.6f, 0.0f, 0.0f);
            break;
        case BUS.Stop:
            GO_BUS.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);    
            BusNumCon = true;
            break;
        case BUS.Depart:
            GO_BUS.GetComponent<Rigidbody>().velocity = new Vector3(-5.6f, 0.0f, 0.0f);
            break;
    }


}
// Update is called once per frame
void Update() 
{
    Ray myRay = new Ray (HEAD_LOG.transform.position, HEAD_LOG.transform.forward);
    
//		UnityEngine.Debug.DrawLine(HEAD_LOG.transform.position, hit.point, Color.yellow);

    if(Physics.Raycast(myRay, out hit, Mathf.Infinity))
    {
        if(hit.collider.tag.Equals("Number"))
        {
            NumberCounted++;
        }
        if(hit.collider.tag.Equals("Destination"))
        {
            DestinationCounted++;
        }
        if(hit.collider.tag.Equals("Color"))
        {
            ColorCounted++;
        }
    }


    if (BusState == BUS.Ready && MiddleVR.VRDeviceMgr.IsKeyPressed(MiddleVR.VRK_SPACE)) 
    {

        TaskTimer.Start();
        BusState = BUS.Arrival;
    }
    else if (BusState == BUS.Arrival)
    {
        if (GO_BUS.transform.position.x < 75.0f)
        {
            BusState = BUS.Stop;
            BusStopTimer.Start();
        }
        
    }
    else if (BusState == BUS.Stop && BusStopTimer.ElapsedMilliseconds > 5000)
    {
        BusState = BUS.Depart;
    }
    else if (BusState == BUS.Depart)
    {
        BusStopTimer.Reset();
        if (GO_BUS.transform.position.x < 45.0f)
        {
            GO_BUS.SetActive(false);
            BusState = BUS.Ready;
            if (BusNumCon)
            {
                if (BusNum < ProbSet3.value[TaskNum].Count() - 1)
                {
                    BusNum++;
                }
                else
                {
                    BusNum = 0;

                    if (TaskNum < ProbSet3.value.Count() - 1)
                    {
                        TaskNum++;
                        TaskTimer.Stop();
                        TaskTimer.Reset();

                        SetPhoneTexture(Goal[TaskNum]);
                    }
                    else
                    {
                        BusState = BUS.Finish;
                        GO_BUS.SetActive(false);
                        TotalTimer.Stop();
                        TaskTimer.Stop();
                        exportResult();

                    }

                }
                BusNumCon = false;
            }
        }
    }
}

void exportResult()
{
    sw.WriteLine(DateTime.Today.ToString("yyyy-MM-dd"));
    sw.WriteLine("Goal" + "," + "Problem");
    
    for (int i = 0; i < ProbSet3.value.Count(); i++)
    {
        sw.Write(ProbGoal.value[i].ToString() + ",");
        
        for (int j = 0; j < ProbSet3.value[i].Count(); j++)
        {
            sw.Write(ProbSet3.value[i][j].ToString() + ",");
        }
        sw.WriteLine();
    }
    
    sw.WriteLine("index" + "," + "task num" + "," + "bus num" + "," +
                 "bus condition" + "," + "selection" + "," + "time" + "," +
                 "task time" + "," + "head X" + "," + "head Y" + "," + "head Z" + "," + 
                 "head x rotate" + "," + "head y rotate" + "," + "head z rotate" + "," + 
                 "left foot x" + "," + "left foot y" + "," + "left foot z" + "," + 
                 "right foot x" + "," + "right foot y" + "," + "right foot z" + "," + 
                 "number count" + "," + "destination count" + "," + "ticket count" + "," + "color count");

    //for (int i = 0; i < HeadLogZList.Count(); i++)
    for (int i = 0; i < index; i++)
    {
        sw.WriteLine(indexList[i] + "," + TaskNumList[i] + "," + BusNumList[i] + "," + ProbSetList[i] + "," + isTakeList[i] + "," + TotalTimerList[i] + ","
                     + TaskTimerList[i] + "," + HeadLogXList[i] + "," + HeadLogYList[i] + "," + HeadLogZList[i] + "," + HeadLogXRotate[i] + "," + HeadLogYRotate[i] + "," + 
                     HeadLogZRotate[i] + "," + LeftFootLogX[i] + "," + LeftFootLogY[i] + "," + LeftFootLogZ[i] + "," + RightFootLogX[i] + "," + RightFootLogY[i] + "," + RightFootLogZ[i] + "," + 
                     NumberCount[i] + "," + DestinationCount[i] + "," + TicketCount[i] "," + ColorCount[i]);
    }
    sw.Flush(); 	sw.Close();		fs.Close();		

    /**
    // 지훈이가 작성했던 부분

    if(isServer){
    for (int i = 0; i < HeadLogZList.Count(); i++)
    {
        sw.Write(indexList[i] + ",");
        sw.Write(TaskNumList[i] + ",");
        sw.Write(BusNumList[i] + ",");
        sw.Write(ProbSetList[i] + ",");
        sw.Write(isTakeList[i] + ",");
        sw.Write(TotalTimerList[i] + ",");
        sw.Write(TaskTimerList[i] + ",");
        sw.Write(HeadLogXList[i] + ",");
        sw.Write(HeadLogYList[i] + ",");
        sw.WriteLine(HeadLogZList[i] + ",");
        sw.Write(HeadLogXRotateList[i] + ",");
        sw.Write(HeadLogYRotateList[i] + ",");
        sw.WriteLine(HeadLogZRotateList[i]);
    }
    }
    /////////////////////////////////////////////////////////////////
}

void OnTriggerStay(Collider other)
{
    if (other.gameObject.name == "Cube" && BusState == BUS.Stop)
    {
        isTake = 1;
        BusStopTimer.Reset();
        BusStopTimer.Start();

        //UnityEngine.Debug.Log("in");
    }
}
void OnTriggerExit(Collider other)
{
    if (other.gameObject.name == "Cube")
    {
        //UnityEngine.Debug.Log("out");
        isTake = 0;
    }
}

/**
void OnGUI()
{
    for(int i= 0 ;i<8;i++){
    GUI.Label (new Rect (10+50*i, 10, 50, 100), ProbGoal.value [i].ToString());
    }
    for(int j=0; j <ProbSet3.value.Count(); j++)
    {
        for(int i=0; i <ProbSet3.value[j].Count(); i++)
        {
            GUI.Label (new Rect (10+50*i, 30+20*j, 50, 100), ProbSet3.value [j][i].ToString());
        }

    }
}
/////////////////////////////////////////////////

private void GenerateProblem()
{
    Goal.Clear ();
    ProbSet.Clear ();
    List<int> temp = Enumerable.Range(0, 8).ToList();
    int idx;
    for (int i = 0; i < 8; i++)
    {

        idx = UnityEngine.Random.Range(0,temp.Count());
        Goal.Add(temp[idx]);
        temp.RemoveAt(idx);
    }

    int[] temp2 = { 3, 3, 3, 3, 3, 3, 3, 3 };
    
    while (temp2.Sum() != 32)
    {
        idx = UnityEngine.Random.Range(0,8);
        if (temp2[idx] < 5)
        {
            temp2[idx]++;
        }
    }
    foreach (int ech in Goal) {
                    MiddleVR.VRLog (0,"Goal : " + ech);
            }
    ProbSet.Add(BusListGenerator(Goal[0], temp2[0]));
    ProbSet.Add(BusListGenerator(Goal[1], temp2[1]));
    ProbSet.Add(BusListGenerator(Goal[2], temp2[2]));
    ProbSet.Add(BusListGenerator(Goal[3], temp2[3]));
    ProbSet.Add(BusListGenerator(Goal[4], temp2[4]));
    ProbSet.Add(BusListGenerator(Goal[5], temp2[5]));
    ProbSet.Add(BusListGenerator(Goal[6], temp2[6]));
    ProbSet.Add(BusListGenerator(Goal[7], temp2[7]));
}

private List<int> BusListGenerator(int goalBus, int countOfBus)
{
    List<List<int>> BusList = new List<List<int>>();

    BusList.Add(new List<int> { 3, 5, 6 });
    BusList.Add(new List<int> { 2, 4, 7 });
    BusList.Add(new List<int> { 1, 4, 7 });
    BusList.Add(new List<int> { 0, 5, 6 });
    BusList.Add(new List<int> { 1, 2, 7 });
    BusList.Add(new List<int> { 0, 3, 6 });
    BusList.Add(new List<int> { 0, 3, 5 });
    BusList.Add(new List<int> { 1, 2, 4 });

    if (countOfBus > 3)
    {
        List<int> NumList = Enumerable.Range(0, 8).ToList();
        foreach (int i in BusList[goalBus])
        {
            NumList.Remove(i);
        }

        int idx;

        for (int i = 0; i < countOfBus - 3; i++)
        {
            idx = UnityEngine.Random.Range(0, NumList.Count());
            BusList[goalBus].Add(NumList[idx]);
        }
    }
    BusList[goalBus].Sort((a, b) => 1 - 2 * UnityEngine.Random.Range(0,2));
    BusList[goalBus].Add(goalBus);

    return BusList[goalBus];
}

private void SetPhoneTexture(int Goal)
{
    GO_PHONE.transform.position = HEAD_LOG.transform.position + new Vector3(0.9f, 0, 0);
    
    switch (Goal)
    {
        case 0:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_G16E);
            break;
        case 1:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_G16S);
            break;
        case 2:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_G18E);
            break;
        case 3:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_G18S);
            break;
        case 4:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_B16E);
            break;
        case 5:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_B16S);
            break;
        case 6:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_B18E);
            break;
        case 7:
            GO_PHONE.GetComponent<Renderer>().material.SetTexture("_MainTex", PHONE_B18S);
            break;
    }
}

private void SetBusObject(int BusNum)
{
    switch (BusNum)
    {
        case 0:
            GO_BUS = BUS_G16E;
            break;
        case 1:
            GO_BUS = BUS_G16S;
            break;
        case 2:
            GO_BUS = BUS_G18E;
            break;
        case 3:
            GO_BUS = BUS_G18S;
            break;
        case 4:
            GO_BUS = BUS_B16E;
            break;
        case 5:
            GO_BUS = BUS_B16S;
            break;
        case 6:
            GO_BUS = BUS_B18E;
            break;
        case 7:
            GO_BUS = BUS_B18S;
            break;
    }
}

// 지훈이가 원래 데이터 출력위해 넣었는데 경원이 지움 
/**
void OnApplicationQuit()
{
    sw.Flush();
    sw.Close();
    fs.Close();	
}
**/

}
