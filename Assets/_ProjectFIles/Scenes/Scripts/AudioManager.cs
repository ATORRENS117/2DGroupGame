using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [Header("Settings")]
    public bool debugToConsole = false;

    public Sound[] sounds;


    
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
        {
            s.source.Play();
        }
        else {
            DebugAudio("Missing PLAY Audio " +  name);
        }      

        DebugAudio(s.name);
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        if (s != null)
        {
            s.source.Stop();
        }
        else
        {
            DebugAudio("Missing STOP Audio " + name);
        }

        DebugAudio(s.name);
    }

    private void DebugAudio(string name)
    {
        if (debugToConsole)
        {
            Debug.Log("Audio Clip: " + name);
        }
    }

    //How to use:
    //Import AudioManager and Sound scripts.
    //Add AudioManager script to an empty game object, reset transform.
    //Add list of sounds in the inspector with an appropriate Sound Name and corresponding audio clip.
    //Make sure pitch is set to 1.
    //Type this line of code below in the area of the script you want the sound to play on. Replace 'Play' with 'Stop' if you need to.
    //FindObjectOfType<AudioManager>().Play("SoundName");
}
