using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public static AudioManager AudioMgr;
    public Sound[] sounds;
    //Handy variable for controling the persistance of the object, useful for reusing the class in other projects.
    public bool dontDestroy = false;
	// Use this for initialization
	void Awake () {
        //Initializing the Singleton Design Pattern for the Audio Manager
        if(dontDestroy)
        {
            if(AudioMgr == null)
            {
                DontDestroyOnLoad(gameObject);
                AudioMgr = this;
            }
            else if(AudioMgr != this) Destroy(gameObject);
        }
        //Initializing Sounds
		foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
	}

    private void Start()
    {
        Play("bg"); //Starts playing the background music.   
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Stop();
    }
}
