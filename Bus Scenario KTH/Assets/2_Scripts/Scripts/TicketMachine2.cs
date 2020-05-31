using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using System.Text;

public class TicketMachine2 : MonoBehaviour
{

    //private Color whiteButtonColor;
    private Color blueButtonColor;
    //private Color yellowButtonColor;
    private Color redButtonColor;
    private Color greenButtonColor;
    //private Color blackButtonColor;

    private Text textScreen;
    private Text paymentText;

    private string ticketColor;
    private string selectTicket;
    private string validateTicket;
    private string payTicket;
    private string getTicket;
    private string caseSwitch;
    private string playerName;
    private string selectZone;



    private MeshRenderer cardValidMeshRenderer;
    private MeshRenderer cardHolderMeshRenderer;
    private MeshRenderer cardNumberMeshRenderer;
    private MeshRenderer cardPlasticMeshRenderer;

    private MeshRenderer ticketMeshRenderer;

    private GameObject ticket;

    public GameObject cardNumber;
    public GameObject cardValid;
    public GameObject cardHolder;
    public GameObject cardPlastic;



    private string sollicitationToLog;



    // Use this for initialization
    void Start()
    {




        InitializeCard();

        textScreen = GameObject.FindGameObjectWithTag("TextScreen").GetComponent<Text>();
        paymentText = GameObject.FindGameObjectWithTag("PaymentText").GetComponent<Text>();
        textScreen = GameObject.FindGameObjectWithTag("Zoneselect").GetComponent<Text>();
        textScreen = GameObject.FindGameObjectWithTag("Ticketselect").GetComponent<Text>();

        ticketColor = "";

        sollicitationToLog = "";



        caseSwitch = "";
        selectTicket = "selectTicket";
        validateTicket = "validateTicket";
        payTicket = "payTicket";
        getTicket = "getTicket";
        selectZone = "selectZone";

        playerName = PlayerPrefs.GetString("name");

        //whiteButtonColor = new Color32(255, 255, 255, 255);
        blueButtonColor = new Color32(64, 173, 255, 255);
        //yellowButtonColor = new Color32(255, 253, 66, 255);
        redButtonColor = new Color32(255, 8, 8, 255);
        greenButtonColor = new Color32(28, 168, 0, 255);
        //blackButtonColor = new Color32(24, 23, 18, 255);

    }

    // Update is called once per frame
    void Update()
    {


    }



    /*****************************************************************/

    /*****************************************************************/
    private void OnTriggerEnter(Collider collider)
    {



        if (collider.gameObject.tag == "TicketButton")
        {
            caseSwitch = "selectTicket";
            caseSwitch = "selectZone";

        }

        switch (caseSwitch)
        {
            case "selectZone":
                if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRZone1button"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;

                }
                else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRZone2button"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;


                }

                else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRZone3button"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;

                }
                break;

            case "selectTicket":
                /*if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRWhiteButton"))
                {
                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket blanc";
                    CardPaymentDisappear();
                    // DeActiveTicket();*/

                if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRBlueButton"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket bleu";
                    CardPaymentDisappear();
                    //DeActiveTicket();

                }
                else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRRedButton"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket rouge";
                    CardPaymentDisappear();
                    //DeActiveTicket();

                }

                else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRGreenButton"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket jaune";
                    CardPaymentDisappear();
                    // DeActiveTicket();0
                }

                /*else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRYellowButton"))
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket jaune";
                    CardPaymentDisappear();
                    // DeActiveTicket();0

                }*/
                break;

            case "validateTicket":
                if (collider.gameObject.tag == "ValidateButton")
                {

                    collider.GetComponent<Renderer>().material.color = Color.cyan;

                }
                break;

            case "payTicket":
                if (collider.gameObject.tag == "TerminalPayment")
                {


                    collider.GetComponent<Renderer>().material.color = Color.cyan;
                    //sollicitationToLog = new EventLog(playerName, "Insérer carte", "Borne de paiement");
                    //EventLogger.Log(sollicitationToLog);
                    print(" 1 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Insère carte, Borne de paiement\n";

                }
                break;
            default:
                break;

        }
    }


    /*****************************************************************/

    /*****************************************************************/


    private void OnTriggerExit(Collider collider)
    {


        switch (caseSwitch)
        {
            case "selectTicket":

                if (collider.gameObject.tag == "TicketButton")
                /* {
                     if (collider.gameObject.name == "VRWhiteButton")
                     {

                         collider.GetComponent<Renderer>().material.color = whiteButtonColor;
                         sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Blanc\n";

                     }*/
                {
                    if (collider.gameObject.name == "VRBlueButton")
                    {

                        collider.GetComponent<Renderer>().material.color = blueButtonColor;
                        sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Bleu\n";

                    }
                    else if (collider.gameObject.name == "VRRedButton")
                    {

                        collider.GetComponent<Renderer>().material.color = redButtonColor;
                        sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Rouge\n";

                    }

                    else if (collider.gameObject.name == "VRGreenButton")
                    {

                        collider.GetComponent<Renderer>().material.color = greenButtonColor;
                        sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Vert\n";

                    }

                    /*else if (collider.gameObject.name == "VRYellowButton")
                    {

                        collider.GetComponent<Renderer>().material.color = yellowButtonColor;
                        sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Jaune\n";

                    }*/
                    textScreen.text = ticketColor + " sélectionné.\n" + "Validez pour confirmer.";
                    caseSwitch = "validateTicket";
                }
                break;
            case "validateTicket":
                if (collider.gameObject.tag == "ValidateButton")
                {
                    textScreen.text = "Vous avez validé le " + ticketColor + ".\n" + "Procédez au paiement.";

                    collider.GetComponent<Renderer>().material.color = greenButtonColor;
                    print("2 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Sélectionne, Bouton Valider\n";
                    StartCoroutine(CardPaymentAppear());


                }

                break;
            case "payTicket":
                if (collider.gameObject.tag == "TerminalPayment")
                {
                    CardPaymentDisappear();

                    /*collider.GetComponent<Renderer>().material.color = blackButtonColor;*/
                    paymentText.text = "Paiement accepté.";
                    print("3 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Retire carte, Borne de paiement\n";

                    ActiveTicket();

                }
                break;
            default:
                // textScreen.text = "Vous n'avez pas sélectionné de ticket " + System.Environment.NewLine + "ou vous avez déjà validé le ticket.";
                break;

        }

    }


    /*****************************************************************/

    /*****************************************************************/
    private void InitializeCard()
    {
        print("initialize cards");


        /*cardPlasticLeft = GameObject.Find("/Controller (left)/Model/Credit_Card/Box001");   
        cardValidLeft = GameObject.Find("/Controller (left)/Model/Credit_Card/Text_OnCard/Month/Year");
        cardHolderLeft = GameObject.FindGameObjectWithTag("CreditCardHolderLeft");
        cardNumberLeft = GameObject.FindGameObjectWithTag("CreditCardNumberLeft");*/

        print("right card name : " + cardPlastic.name);

        cardPlasticMeshRenderer = cardPlastic.GetComponent<MeshRenderer>();
        cardValidMeshRenderer = cardValid.GetComponent<MeshRenderer>();
        cardHolderMeshRenderer = cardHolder.GetComponent<MeshRenderer>();
        cardNumberMeshRenderer = cardNumber.GetComponent<MeshRenderer>();


    }


    /*****************************************************************/

    /*****************************************************************/


    private void DeActiveTicket()
    {
        ticketMeshRenderer.enabled = false;
        ticket.SetActive(false);
    }


    /*****************************************************************/

    /*****************************************************************/

    private void ActiveTicket()
    {
        ticket = GameObject.FindGameObjectWithTag("Ticket");
        GameObject newTicket = new GameObject();

        newTicket = ticket;

        ticketMeshRenderer = newTicket.GetComponent<MeshRenderer>();
        //yield return new WaitForSeconds(3f);

        newTicket.GetComponent<Renderer>().material.color = getTicketColor();

        newTicket.SetActive(true);
        newTicket.transform.position = new Vector3(67.2f, 2.33f, 121.22f);
        ticketMeshRenderer.enabled = true;
        print("4 TicketMachine sollicitationToLog : " + sollicitationToLog);
        sollicitationToLog += GlobalTime.globalTime + ", Vending machine, Distribue, " + ticketColor + "\n";

        StartCoroutine(NewPaymentText());
    }


    /*****************************************************************/

    /*****************************************************************/


    IEnumerator NewPaymentText()
    {
        caseSwitch = "selectTicket";
        yield return new WaitForSeconds(5);

        paymentText.text = "Payez en touchant la borne.";
        textScreen.text = "Sélectionnez un ticket.";

    }
    /*****************************************************************/

    /*****************************************************************/

    private IEnumerator CardPaymentAppear()
    {



        //card.transform.parent = this.transform;
        //GameObject.FindGameObjectWithTag("CreditCard").gameObject.GetComponent<MeshRenderer>.enabled();

        //faire apparaître la carte de paiement



        yield return new WaitForSeconds(0.3f);
        print("this.name : " + this.name);


        cardValid.SetActive(true);
        cardHolder.SetActive(true);
        cardPlastic.SetActive(true);
        cardNumber.SetActive(true);


        cardValidMeshRenderer.enabled = true;
        cardHolderMeshRenderer.enabled = true;
        cardPlasticMeshRenderer.enabled = true;
        cardNumberMeshRenderer.enabled = true;



        caseSwitch = "payTicket";
    }


    /*****************************************************************/

    /*****************************************************************/

    private void CardPaymentDisappear()
    {
        //GameObject.FindGameObjectWithTag("CreditCard").gameObject.GetComponent<MeshRenderer>.enabled();
        //faire disparaître la carte de paiement


        cardValidMeshRenderer.enabled = false;
        cardHolderMeshRenderer.enabled = false;
        cardPlasticMeshRenderer.enabled = false;
        cardNumberMeshRenderer.enabled = false;


        cardValid.SetActive(false);
        cardHolder.SetActive(false);
        cardPlastic.SetActive(false);
        cardNumber.SetActive(false);



    }


    /*****************************************************************/

    /*****************************************************************/

    public string getTicketColorString()
    {
        return ticketColor;
    }

    /*****************************************************************/

    /*****************************************************************/
    public Color getTicketColor()
    {
        Color color = new Color();

        /*if (getTicketColorString().Equals("Ticket blanc"))
        {
            color = whiteButtonColor;
        }*/
        if (getTicketColorString().Equals("Ticket bleu"))
        {
            color = blueButtonColor;
        }
        else if (getTicketColorString().Equals("Ticket rouge"))
        {
            color = redButtonColor;
        }
        else if (getTicketColorString().Equals("Ticket vert"))
        {
            color = greenButtonColor;
        }

        /* else if (getTicketColorString().Equals("Ticket jaune"))
         {
             color = yellowButtonColor;
         }*/


        return color;
    }

    public void EndLog()
    {
        print("5 TicketMachine sollicitationToLog : " + sollicitationToLog);
        File.AppendAllText(EventLogger.getPathEventLogger(), sollicitationToLog, Encoding.UTF8);
    }


}


