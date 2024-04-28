using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUp_Box : MonoBehaviour
{
    public GameObject PopUpBox;
    public Animator animator;
    public TMP_Text popUpText;

    public void PopUp(string text)
    {
        popUpBox.SetActive(true);
        popUpText.text = text;
        animator.SetSetTrigger("pop");
    }  
}
