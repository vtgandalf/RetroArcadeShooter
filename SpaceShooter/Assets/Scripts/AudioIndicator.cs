using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioIndicator : MonoBehaviour {

	public AudioClip sound;
    public AudioSource source;
    // Use this for initialization
    void Start()
    {
        source.clip = sound;
        source.loop = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound()
    {
        source.Play();
    }
}
