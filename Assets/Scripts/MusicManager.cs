using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] MusicClips;

    private AudioSource source;
    int currentTrack;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        currentTrack = Random.Range(0, MusicClips.Length);
        source.clip = MusicClips[currentTrack];
        source.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (source.isPlaying == false)
        {
            currentTrack = Random.Range(0, MusicClips.Length);
            source.clip = MusicClips[currentTrack];
            source.Play();
        }
	}
}
