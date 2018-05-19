using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyOnAudioFinish : MonoBehaviour {

    private AudioSource source;
    private bool hasStarted = false;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>(); ;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasStarted)
        {
            if (source.isPlaying)
            {
                hasStarted = true;
            }
        }
        else
        {
            if (!source.isPlaying)
            {
                Destroy(gameObject);
            }
        }
	}
}
