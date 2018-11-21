using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMainTheme : MonoBehaviour {
	public AudioClip intro1;
	public AudioClip intro2;
	public AudioClip loop;
	public AudioSource intro1Source;
	public AudioSource intro2Source;
	public AudioSource loopSource;
	// Use this for initialization
	void Start () {
		intro1Source.clip = intro1;
		intro2Source.clip = intro2;
		loopSource.clip = loop;
		intro1Source.Play();
		intro2Source.PlayDelayed(intro1.length);
		loopSource.PlayDelayed(intro1.length + intro2.length);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
