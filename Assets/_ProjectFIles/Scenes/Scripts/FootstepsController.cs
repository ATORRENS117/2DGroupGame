using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{

    public bool walking = false;

    public float timer;
    public float interval =0.5f;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (walking)
        {
            timer += Time.deltaTime;

            if (timer > interval)
            {
                timer = 0;
                //play footstep
                FindObjectOfType<AudioManager>().Play("Footsteps");
                Debug.Log("play footstep-----------------");

            }
        }


    }

    
}
