using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	 public AudioClip[] clips;
	 int songNumber;
	 AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audioSource.isPlaying)
        {
			GetRandomsong();
            audioSource.clip = clips[songNumber];
            audioSource.Play();
        }
	}

	void GetRandomsong(){
		songNumber = Random.Range(0, clips.Length);
	}
}
