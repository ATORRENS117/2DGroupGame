using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HellEnvironmentSound : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Lava");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
