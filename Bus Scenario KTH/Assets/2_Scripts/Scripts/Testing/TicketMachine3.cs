using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TicketMachine3 : MonoBehaviour
{
    private Color whiteButtonColor;
    private Color blueButtonColor;
    private Color yellowButtonColor;
    private Color redButtonColor;
    private Color greenButtonColor;
    private Color blackButtonColor;

    private Text textScreen;
    private Text paymentText;
    private Text zonetext; //show the 'zone' that user choosen
    private Text tickettext;//show the 'ticket' that user choosen

    private string ticketColor;
    private string playerName;
    private string zone;

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

    void Start()
    {
        InitializeCard();

        textScreen = GameObject.FindGameObjectWithTag("TextScreen").GetComponent<Text>();
        paymentText = GameObject.FindGameObjectWithTag("PaymentText").GetComponent<Text>();
        zonetext = GameObject.FindGameObjectWithTag("zonetext").GetComponent<Text>();
        tickettext = GameObject.FindGameObjectWithTag("tickettext").GetComponent<Text>();

        ticketColor = "";

        playerName = PlayerPrefs.GetString("name");

        whiteButtonColor = new Color32(255, 255, 255, 255);
        blueButtonColor = new Color32(64, 173, 255, 255);
        yellowButtonColor = new Color32(255, 253, 66, 255);
        redButtonColor = new Color32(255, 8, 8, 255);
        greenButtonColor = new Color32(28, 168, 0, 255);
        blackButtonColor = new Color32(24, 23, 18, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone1button"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("z1_In");
        }
        else if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone2button"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("z2_In");
        }
        else if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone3button"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("z3_In");
        }
        else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRBlueButton"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("BT_In");
            //DeActiveTicket();
        }
        else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRRedButton"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("RT_In");
            //DeActiveTicket();
        }
        else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRGreenButton"))
        {
            collider.GetComponent<Renderer>().material.color = Color.blue;
            CardPaymentDisappear();
            print("GT_In");
        }
        else if (collider.gameObject.tag == "ValidateButton")
        {
            collider.GetComponent<Renderer>().material.color = Color.cyan;
            print("VD_In");
        }
        else if (collider.gameObject.tag == "TerminalPayment")
        {
            collider.GetComponent<Renderer>().material.color = Color.cyan;
            print("PM_In");
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone1button"))
        {
            collider.GetComponent<Renderer>().material.color = whiteButtonColor;
            zonetext.text = "Zone1";
            textScreen.text = zone + " sélectionné.\n" + "Choisissez un billet.";
            print("z1_Out");
        }
        else if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone2button"))
        {
            collider.GetComponent<Renderer>().material.color = whiteButtonColor;
            zonetext.text = "Zone2";
            textScreen.text = zone + " sélectionné.\n" + "Choisissez un billet.";
            print("z2_Out");
        }

        else if ((collider.gameObject.tag == "ZoneButton") && (collider.gameObject.name == "VRZone3buttonn"))
        {
            collider.GetComponent<Renderer>().material.color = whiteButtonColor;
            zonetext.text = "Zone3";
            textScreen.text = zone + " sélectionné.\n" + "Choisissez un billet.";
            print("z3_Out");
        }
        else if ((collider.gameObject.tag == "TicketButton")&&(collider.gameObject.name == "VRBlueButton"))
            {
                collider.GetComponent<Renderer>().material.color = blueButtonColor;
                tickettext.text = "Bleu";
                ticketColor = "Ticket bleu";
                print("BT_Out");

            }
         else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRRedButton"))
            {
                collider.GetComponent<Renderer>().material.color = redButtonColor;
                tickettext.text = "Rouge";
                ticketColor = "Ticket rouge";
                textScreen.text = ticketColor + " sélectionné.\n" + "Validez pour confirmer.";
                print("RT_Out");
            }

        else if ((collider.gameObject.tag == "TicketButton") && (collider.gameObject.name == "VRGreenButton"))
             {
                collider.GetComponent<Renderer>().material.color = greenButtonColor;
                tickettext.text = "Vert";
                ticketColor = "Ticket vert";
                textScreen.text = ticketColor + " sélectionné.\n" + "Validez pour confirmer.";
                print("GT_Out");
            }
        else if (collider.gameObject.tag == "ValidateButton")
        {
            textScreen.text = "Vous avez validé le " + zone + ticketColor + ".\n" + "Procédez au paiement.";

            collider.GetComponent<Renderer>().material.color = yellowButtonColor;
            StartCoroutine(CardPaymentAppear());
            print("VD_Out");
        }
        else if (collider.gameObject.tag == "TerminalPayment")
        {
            CardPaymentDisappear();

            collider.GetComponent<Renderer>().material.color = blackButtonColor;
            paymentText.text = "Paiement accepté.";
            print("PM_Out");
            ActiveTicket();

        }
    }
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
    private void DeActiveTicket()
    {
        ticketMeshRenderer.enabled = false;
        ticket.SetActive(false);
    }
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
        StartCoroutine(NewPaymentText()); //뉴페이먼트 텍스트로 넘어가서 다음에 다시 버튼을 누를때 까지 대기상태로 돌리는 것
    }

    IEnumerator NewPaymentText()
    {
        yield return new WaitForSeconds(5);

        paymentText.text = "Payez en touchant la borne.";
        textScreen.text = "Sélectionnez un ticket.";
        zonetext.text = "";
        tickettext.text = "";
    }
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
    }

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
    public string getTicketColorString()
    {
        return ticketColor;
    }
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
}
