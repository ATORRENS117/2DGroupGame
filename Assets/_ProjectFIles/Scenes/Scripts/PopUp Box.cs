using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp_Box : MonoBehaviour
{

    public GameObject popUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void Start()
    {
        popUpBox.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //pop up dialog
            PopupDialog();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
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
        popUpBox.SetActive(true);
        print("POPUP");
    }
    private void CloseDialog()
    {
        //close here
        popUpBox.SetActive(false);
        print("REMOVE POPUP");
    }
}
