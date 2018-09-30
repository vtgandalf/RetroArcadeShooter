using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public AudioClip gun;
	public AudioClip hit;
	public AudioSource source;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayGun()
	{
		source.clip = gun;
		source.Play();
	}

    public void PlayHit()
	{
		source.clip = hit;
        source.Play();
	}
}
