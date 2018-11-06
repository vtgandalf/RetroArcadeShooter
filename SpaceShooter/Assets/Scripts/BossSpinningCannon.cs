using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpinningCannon : MonoBehaviour {
	public BossCannonType1 cannon1;
	public BossCannonType1 cannon2;
	public BossCannonType1 cannon3;
	public BossCannonType1 cannon4;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
	{
		cannon1.FireSingle();
		cannon2.FireSingle();
		cannon3.FireSingle();
		cannon4.FireSingle();
	}
}
