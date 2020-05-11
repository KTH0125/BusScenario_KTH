using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreditCard : MonoBehaviour
{

    private Text paymentText;
    private TicketMachine T = new TicketMachine();
    private GameObject ticket;

    // Use this for initialization
    void Start()
    {
        ticket = GameObject.FindGameObjectWithTag("Ticket");

        

        print("Start CreditCard");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        print("OnCollisionEnter" + collision.gameObject.name);
        if (collision.gameObject.tag == "TerminalPayment")
        {
            paymentText = collision.gameObject.GetComponent<Text>();

            ticket.SetActive(true);
            paymentText.text = "Paiement" + System.Environment.NewLine + "en cours ...";
            ticket.GetComponent<Renderer>().material.color = T.getTicketColor();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        print("OnTriggerEnter" + collider.gameObject.name);
    }

}
