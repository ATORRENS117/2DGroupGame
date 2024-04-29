using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition_Hell2Cave : MonoBehaviour
{
    //public GameObject triggerObject;
    public string objectSound = "Enter Sound Name"; //add the name of the string for the sound here
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("CaveAmbience");
            FindObjectOfType<AudioManager>().Stop("HellAmbience");
            FindObjectOfType<AudioManager>().Stop("Lava");
        }
    }

   
}
