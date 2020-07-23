﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System.IO;
using System.Text;

public class TicketMachine2 : MonoBehaviour
{

    private Color whiteButtonColor;
    private Color blueButtonColor;
    private Color yellowButtonColor;
    private Color redButtonColor;
    private Color greenButtonColor;
    private Color blackButtonColor;

    public Text textScreen;
    public Text paymentText;
    public Text zonetext; //show the 'zone' that user choosen
    public Text tickettext;//show the 'ticket' that user choosen

    private string ticketColor;
    //private string caseSwitch;

    private bool isZoneChosen;
    private bool isColorChosen;
    private bool isValidateChosen;

    private string playerName;
    private string zone;
    private string selectTicket;
    private string validateTicket;
    private string payTicket;
    private string getTicket;
    private string selectZone;

    /*private string btnZ1;
    private string btnZ2;
    private string btnZ3;
    private string btnCB;
    private string btnCR;
    private string btnCG;*/

    public GameObject creditcard;

    public GameObject ticket;

    private MeshRenderer cardValidMeshRenderer;
    private MeshRenderer cardHolderMeshRenderer;
    private MeshRenderer cardNumberMeshRenderer;
    private MeshRenderer cardPlasticMeshRenderer;

    //private MeshRenderer ticketMeshRenderer;

    //private GameObject ticket;

    //public GameObject cardNumber;
    //public GameObject cardValid;
    //public GameObject cardHolder;
    //public GameObject cardPlastic;



    private string sollicitationToLog;



    // Use this for initialization
    void Start()
    {


        //ticket = GameObject.FindGameObjectWithTag("Ticket");
        ticket.SetActive(false);

        InitializeCard();

        //textScreen = GameObject.FindGameObjectWithTag("TextScreen").GetComponent<Text>();
        //paymentText = GameObject.FindGameObjectWithTag("PaymentText").GetComponent<Text>();
        //zonetext = GameObject.FindGameObjectWithTag("zonetext").GetComponent<Text>();
        //tickettext = GameObject.FindGameObjectWithTag("tickettext").GetComponent<Text>();

        //if (zonetext == null)
        //    throw new MissingReferenceException("zonetext");

        ticketColor = "";

        sollicitationToLog = "";



        //caseSwitch = "";
        //selectTicket = "selectTicket";
        //validateTicket = "validateTicket";
        //payTicket = "payTicket";
        //getTicket = "getTicket";
        //selectZone = "selectZone";

        playerName = PlayerPrefs.GetString("name");

        whiteButtonColor = new Color32(255, 255, 255, 255);
        blueButtonColor = new Color32(64, 173, 255, 255);
        yellowButtonColor = new Color32(255, 253, 66, 255);
        redButtonColor = new Color32(255, 8, 8, 255);
        greenButtonColor = new Color32(28, 168, 0, 255);
        blackButtonColor = new Color32(24, 23, 18, 255);

        /*btnZ1 = "VRZone1button";
        btnZ2 = "VRZone2button";
        btnZ3 = "VRZone3button";
        btnCR = "VRRedButton";
        btnCB = "VRBlueButton";
        btnCG = "VRGreenButton";*/



    }

    // Update is called once per frame
    void Update()
    {


    }



    /*****************************************************************/

    /*****************************************************************/
    private void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        //print(collider.gameObject.name);
        //if (collider.gameObject.tag == "ZoneButton")
        //{
        //    caseSwitch = "selectZone";
        //}

        switch (tag)
        {
            case "ZoneButton":
                print("enter " + collider.gameObject.name);

                collider.GetComponent<Renderer>().material.color = Color.blue;
                CardPaymentDisappear();
                break;

            case "TicketButton":
                if (collider.gameObject.name == "VRBlueButton")
                {
                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket bleu";
                    CardPaymentDisappear();

                }
                else if (collider.gameObject.name == "VRRedButton")
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket rouge";
                    CardPaymentDisappear();

                }
                else if (collider.gameObject.name == "VRGreenButton")
                {

                    collider.GetComponent<Renderer>().material.color = Color.blue;
                    ticketColor = "Ticket jaune";
                    CardPaymentDisappear();
                }
                break;

            case "ValidateButton":
                if (isZoneChosen && isColorChosen)
                {
                    collider.GetComponent<Renderer>().material.color = Color.cyan;
                    print("VD_In");
                }
                break;

            case "TerminalPayment":
                if (isValidateChosen)
                {
                    collider.GetComponent<Renderer>().material.color = Color.cyan;
                    //sollicitationToLog = new EventLog(playerName, "Insérer carte", "Borne de paiement");
                    //EventLogger.Log(sollicitationToLog);
                    print(" 1 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    sollicitationToLog += GlobalTime.globalTime + ", " + playerName + ", Insère carte, Borne de paiement\n";
                    print("PM_In");
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
        string tag = collider.gameObject.tag;

        switch (tag)
        {
            case "ZoneButton":

                if (collider.gameObject.name == "VRZone1button")
                    {
                    zone = "Zone1";
                    print("z1_Out");
                     }
                else if (collider.gameObject.name == "VRZone2button")
                {
                    zone = "Zone2";
                    print("z2_Out");
                }
                else if (collider.gameObject.name == "VRZone3button")
                {
                    zone = "Zone3";
                    print("z3_Out");
                }

                print("debug " + this.gameObject.name);
                print("exit1 " + collider.gameObject.name);
                zonetext.text = zone;
                print("exit2 " + collider.gameObject.name);
                textScreen.text = zone + " sélectionné.\n" + "Choisissez un billet.";
                print("exit3 " + collider.gameObject.name);
                collider.GetComponent<Renderer>().material.color = whiteButtonColor;
                print("exit4 " + collider.gameObject.name);

                isZoneChosen = true;

                    //caseSwitch = "selectTicket";
                break;

            case "TicketButton":

                if ((collider.gameObject.name == "VRBlueButton"))
                {
                    tickettext.text = "Bleu";
                    ticketColor = "Ticket bleu";
                    collider.GetComponent<Renderer>().material.color = blueButtonColor;
                    print("BT_Out");

                }
                else if ((collider.gameObject.name == "VRRedButton"))
                {
                    tickettext.text = "Rouge";
                    ticketColor = "Ticket rouge";
                    collider.GetComponent<Renderer>().material.color = redButtonColor;
                    print("RT_Out");

                }

                else if ((collider.gameObject.name == "VRGreenButton"))
                {
                    tickettext.text = "Vert";
                    ticketColor = "Ticket vert";
                    collider.GetComponent<Renderer>().material.color = greenButtonColor;
                    print("GT_Out");

                }

                textScreen.text = ticketColor + " sélectionné.\n" + "Validez pour confirmer.";
                //caseSwitch = "validateTicket";
                isColorChosen = true;
                break;

            case "ValidateButton":
                //if (collider.gameObject.tag == "ValidateButton")
                if (isZoneChosen && isColorChosen)
                {
                    textScreen.text = "Vous avez validé le " + ticketColor + ".\n" + "Procédez au paiement.";

                    collider.GetComponent<Renderer>().material.color = yellowButtonColor;
                    print("2 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    CardPaymentAppear();
                    print("VD_Out");
                    //caseSwitch = "payTicket";

                    isValidateChosen = true;
                }

                break;

            case "TerminalPayment":
                if (isValidateChosen)
                {
                    CardPaymentDisappear();

                    collider.GetComponent<Renderer>().material.color = blackButtonColor;
                    paymentText.text = "Paiement accepté.";
                    print("3 TicketMachine sollicitationToLog : " + sollicitationToLog);
                    print("PM_Out");
                    ActiveTicket();

                    isZoneChosen = false;
                    isColorChosen = false;
                    isValidateChosen = false;
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

        //print("right card name : " + cardPlastic.name);

        //cardPlasticMeshRenderer = cardPlastic.GetComponent<MeshRenderer>();
        //cardValidMeshRenderer = cardValid.GetComponent<MeshRenderer>();
        //cardHolderMeshRenderer = cardHolder.GetComponent<MeshRenderer>();
        //cardNumberMeshRenderer = cardNumber.GetComponent<MeshRenderer>();


    }


    /*****************************************************************/

    /*****************************************************************/


    private void DeActiveTicket()
    {
        //ticketMeshRenderer.enabled = false;
        ticket.SetActive(false);
    }


    /*****************************************************************/

    /*****************************************************************/

    private void ActiveTicket()
    {
        //ticket = GameObject.FindGameObjectWithTag("Ticket");
        GameObject newTicket = Instantiate(this.ticket) ;
        newTicket.transform.parent = this.ticket.transform.parent;
        newTicket.transform.position = this.ticket.transform.position;
        newTicket.transform.localRotation = this.ticket.transform.localRotation;
        newTicket.transform.localScale = this.ticket.transform.localScale;
        
        //newTicket = ticket;

        MeshRenderer ticketMeshRenderer = newTicket.GetComponent<MeshRenderer>();
        //yield return new WaitForSeconds(3f);

        newTicket.GetComponent<Renderer>().material.color = getTicketColor();

        newTicket.SetActive(true);
        //newTicket.transform.position = new Vector3(72.5f, 2.3f, 112.9f);
        //ticketMeshRenderer.enabled = true;
        print("4 TicketMachine sollicitationToLog : " + sollicitationToLog);
        sollicitationToLog += GlobalTime.globalTime + ", Vending machine, Distribue, " + ticketColor + "\n";

        StartCoroutine(NewPaymentText()); //뉴페이먼트 텍스트로 넘어가서 다음에 다시 버튼을 누를때 까지 대기상태로 돌리는 것
    }


    /*****************************************************************/

    /*****************************************************************/


    IEnumerator NewPaymentText()
    {
        //caseSwitch = "selectTicket";
        yield return new WaitForSeconds(5);

        paymentText.text = "Payez en touchant la borne.";
        textScreen.text = "Sélectionnez un ticket.";

    }
    /*****************************************************************/

    /*****************************************************************/

    private void CardPaymentAppear()
    {
        print("this.name : " + this.name);

        creditcard.SetActive(true);
        //cardValid.SetActive(true);
        //cardHolder.SetActive(true);
        //cardPlastic.SetActive(true);
        //cardNumber.SetActive(true);

        //cardValidMeshRenderer.enabled = true;
        //cardHolderMeshRenderer.enabled = true;
        //cardPlasticMeshRenderer.enabled = true;
        //cardNumberMeshRenderer.enabled = true;

        //caseSwitch = "payTicket";
    }


    /*****************************************************************/

    /*****************************************************************/

    private void CardPaymentDisappear()
    {
        //GameObject.FindGameObjectWithTag("CreditCard").gameObject.GetComponent<MeshRenderer>.enabled();
        //faire disparaître la carte de paiement

        creditcard.SetActive(false);

        //cardValidMeshRenderer.enabled = false;
        //cardHolderMeshRenderer.enabled = false;
        //cardPlasticMeshRenderer.enabled = false;
        //cardNumberMeshRenderer.enabled = false;

        //cardValid.SetActive(false);
        //cardHolder.SetActive(false);
        //cardPlastic.SetActive(false);
        //cardNumber.SetActive(false);
    }


    /*****************************************************************/

    /*****************************************************************/

    public string getTicketColorString()
    {
        return ticketColor;
    }

    public string getTicketZoneString()
    {
        return zone;
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


