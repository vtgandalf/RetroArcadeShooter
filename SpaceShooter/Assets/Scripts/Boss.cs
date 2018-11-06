using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttackStyle{
	Aim, Spin
}
public class Boss : MonoBehaviour {
	public AttackStyle style;
	public int Health;
	public float attack1FireRate;
	public float attack2FireRate;
	public int attack1NumberOfShots;
	public int attack2NumberOfShots;
	private float timer;
	public BossCannonType1 cannonA;
	public BossCannonType1 cannonB;
	public BossSpinningCannon cannonS;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		switch(style)
		{
			case AttackStyle.Aim:
				if (timer >= attack1FireRate) 
				{
					Attack1();
					timer = 0f;
				}
				break;
			case AttackStyle.Spin:
				if (timer >= attack2FireRate) 
				{
					Attack2();
					timer = 0f;
				}
				break;
		}
	}

    public void Attack1()
	{
		cannonA.FireSingleTowardsPlayer();
        cannonB.FireSingleTowardsPlayer();
	}

	public void Attack2()
	{
		cannonS.Fire();
	}
}