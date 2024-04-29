using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environmentsound : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManager>().Play("Lava");
        FindObjectOfType<AudioManager>().Play("HellAmbience");
    }

}
