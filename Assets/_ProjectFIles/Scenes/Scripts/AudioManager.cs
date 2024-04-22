using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
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
        s.source.Play();
    }

    public void Stop (string name)
    {
        Sound s = Array.Find(sounds, sounds => sounds.name == name);
        s.source.Stop();
    }

    //How to use:
    //Import AudioManager and Sound scripts.
    //Add AudioManager script to an empty game object, reset transform.
    //Add list of sounds in the inspector with an appropriate Sound Name and corresponding audio clip.
    //Make sure pitch is set to 1.
    //Type this line of code below in the area of the script you want the sound to play on. Replace 'Play' with 'Stop' if you need to.
    //FindObjectOfType<AudioManager>().Play("SoundName");
}
