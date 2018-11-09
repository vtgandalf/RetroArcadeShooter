using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BackgroundTytpe{
	Fore, Mid, Back
}

public class BackgroundSynchManager : MonoBehaviour {

    private Vector2 offsetFore;
	private Vector2 offsetMid;
	private Vector2 offsetBack;
	public float speedMid = 140;
	public float speedFore = 17;
	public float speedBack = 30;
	// Use this for initialization
	void Start () {
		offsetFore = new Vector2(0, 0);
		offsetMid = new Vector2(0, 0);
		offsetBack = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		offsetFore.y += Time.deltaTime / speedFore;
		offsetMid.y += Time.deltaTime / speedMid;
		offsetBack.y += Time.deltaTime / speedBack;
	}

	public Vector2 OffsetFore
    {
        get { return this.offsetFore; }
    }

	public Vector2 OffsetMid
	{
		get { return this.offsetMid; }
	}

	public Vector2 OffsetBack
    {
        get { return this.offsetBack; }
    }
}
