using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] MusicClips;

    private AudioSource source;
    int currentTrack;
    float defaultVolume;

    public float PauseBetweenTracks = 5.0f;
    private float pauseTimer = 0f;
    private int numPlays = 1;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        currentTrack = Random.Range(0, MusicClips.Length);
        source.clip = MusicClips[currentTrack];
        source.Play();
        pauseTimer = PauseBetweenTracks;
        defaultVolume = source.volume;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //if (numPlays > 0 && source.time >= source.clip.length)
        //{
        //    source.Play();
        //    numPlays--;
        //}
        //else if (source.isPlaying == false)
        //{
        //    if (pauseTimer > 0f)
        //    {
        //        pauseTimer -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        numPlays = Random.Range(0, 2);
        //        pauseTimer = PauseBetweenTracks;
        //        source.volume = defaultVolume;
        //        currentTrack = Random.Range(0, MusicClips.Length);
        //        source.clip = MusicClips[currentTrack];
        //        source.Play();
        //    }
        //}
        //else if ( numPlays == 0 && source.time > source.clip.length * (1f-defaultVolume))
        //{
        //    source.volume = 1.0f - (source.time / source.clip.length);
        //}
	}
}
