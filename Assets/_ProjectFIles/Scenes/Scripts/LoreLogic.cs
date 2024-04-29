using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoreLogic : MonoBehaviour
{
    //public FreeRoamObjectBehavior objectBehaviour;
    //public Unit troop;
    //public SignalItem contextOn;
    //public SignalItem contextOff;

    public GameObject dialogueBox;
    public TMP_Text dialogueText;
    public string dialogue;
    public bool dialogueActive;
    public string popUp;
    bool playerInRange = false;
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            //pop up dialog
            PopupDialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //vlose dialog
            CloseDialog();
        }
    }

    private void PopupDialog()
    {
        //pop up here
    }
    private void CloseDialog()
    {
        //close here
    }

}
