using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList.Element_Adder_Menu;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition_Hell2Cave : MonoBehaviour
{
    public string objectSound;
    public string previousSound;
    public string previousSound1;
    public bool hasChanged = false;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //CHECK THE PLAYER AND SWITCH TRUE OR FALSE
        if (collision.CompareTag("Player"))
        {
            if(hasChanged == false)
            {
                hasChanged = true;
            }
           else
            {
                hasChanged = false;
            }
        }

        //PLAYED THE SOUND BASED ON THE SWITCH
        switch (hasChanged)
        {
            case true:
                FindObjectOfType<AudioManager>().Play(objectSound);
                FindObjectOfType<AudioManager>().Stop(previousSound);
                FindObjectOfType<AudioManager>().Stop(previousSound1);
                print("Played");
                break;

            case false:
                FindObjectOfType<AudioManager>().Play(previousSound);
                FindObjectOfType<AudioManager>().Play(previousSound1);
                FindObjectOfType<AudioManager>().Stop(objectSound);
                break;
        }
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha8))
    //    {
    //        FindObjectOfType<AudioManager>().Play(objectSound);
    //        FindObjectOfType<AudioManager>().Stop(previousSound);

    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha9))
    //    {
    //        FindObjectOfType<AudioManager>().Play(previousSound);
    //        FindObjectOfType<AudioManager>().Stop(objectSound);

    //    }
    //}



    }
