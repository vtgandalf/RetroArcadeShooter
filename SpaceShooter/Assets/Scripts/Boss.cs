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
	private int attackNumberOfShots;
	public float timeBetweenAttackPhases;
	private float timer;
	private float shootingTimer;
	public BossCannonType1 cannonA;
	public BossCannonType1 cannonB;
	public BossSpinningCannon cannonS;
	private int shotCounter;
	private int modeCounter;
	public int attacksBeforeModeSwitch;
	// Use this for initialization
	void Start () {
		timer = timeBetweenAttackPhases;
		modeCounter = 0;
		shootingTimer = 0f;
		shotCounter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		ToggleMode();
        shootingTimer += Time.deltaTime;

		if (style == AttackStyle.Aim) attackNumberOfShots = attack1NumberOfShots;
		else attackNumberOfShots = attack2NumberOfShots;
		if(shotCounter >= attackNumberOfShots)
		{
			shotCounter = 0;
			timer = 0f;
			Debug.LogError(modeCounter);
			modeCounter++;
		}
		if (shotCounter < attack2NumberOfShots && timer >= timeBetweenAttackPhases)
		{
			Attacking();
		}
		else { timer += Time.deltaTime; }
	}

    public void Attack1()
	{
        shotCounter++;
		cannonA.FireSingleTowardsPlayer();
        cannonB.FireSingleTowardsPlayer();
	}

	public void Attack2()
	{
        shotCounter++;
		cannonS.Fire();
	}

	public void Attacking()
	{
		switch (style)
        {
            case AttackStyle.Aim:
                if (shootingTimer >= attack1FireRate)
                {
                    Attack1();
                    shootingTimer = 0f;
                }
                break;
            case AttackStyle.Spin:
                if (shootingTimer >= attack2FireRate)
                {
                    Attack2();
                    shootingTimer = 0f;
                }
                break;
        }
	}

	public void ToggleMode()
	{
		if(modeCounter >= attacksBeforeModeSwitch)
		{
			modeCounter = 0;
			timer = -2;
			if (style == AttackStyle.Aim) style = AttackStyle.Spin;
			else style = AttackStyle.Aim;
		}
		if(modeCounter == attacksBeforeModeSwitch/2 && shotCounter >= attackNumberOfShots)
		{
			cannonS.ToggleRotationDirection();
		}
	}
}