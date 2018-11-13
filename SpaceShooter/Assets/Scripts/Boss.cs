using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AttackStyle{
	Aim, Spin
}
public class Boss : MonoBehaviour {
	public AttackStyle style;
	private AttackStyle lastStyle;
	public int initHP;
	private int currentHP;
	public float attack1FireRate;
	public float attack2FireRate;
	public int attack1NumberOfShots;
	public int attack2NumberOfShots;
	private int attackNumberOfShots;
	public float timeBetweenAttackPhases;
	private float timer;
	private float shootingTimer;
	public int delayFromSpinToAim;
	public int delayFromAimToSpin;
	public BossCannonType1 cannonA;
	public BossCannonType1 cannonB;
	public BossSpinningCannon cannonS;
	private int shotCounter;
	private int modeCounter;
	public int attacksBeforeModeSwitch;
	public Progress healthBar;
	private Animation animation;
	private bool entranceFinished;
	public ObjectsManager objectsManager;
	public Player player;
	private GameObject playerOrbit;

	// Use this for initialization
	void Start () {
		entranceFinished = false;
		animation = this.gameObject.GetComponent<Animation>();
		currentHP = initHP;
		timer = timeBetweenAttackPhases;
		modeCounter = 0;
		shootingTimer = 0f;
		shotCounter = 0;
		lastStyle = style;
		healthBar.ValueBossHealth((float) initHP,(float) currentHP);
		animation.Play("BossEntrance");
		cannonA.objectsManager = objectsManager;
		cannonB.objectsManager = objectsManager;
		cannonS.objectsManager = objectsManager;
		playerOrbit = player.gameObject.transform.GetChild(0).gameObject;
		playerOrbit.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(entranceFinished == true)
		{
			ToggleMode();
            shootingTimer += Time.deltaTime;

            if (style == AttackStyle.Aim) attackNumberOfShots = attack1NumberOfShots;
            else attackNumberOfShots = attack2NumberOfShots;
            if (shotCounter >= attackNumberOfShots)
            {
                shotCounter = 0;
                timer = 0f;
                //Debug.LogError(modeCounter);
                modeCounter++;
            }
            if (shotCounter < attack2NumberOfShots && timer >= timeBetweenAttackPhases)
            {
                Attacking();
            }
            else { timer += Time.deltaTime; }
		}      
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
		lastStyle = style;
	}

	public void ToggleMode()
	{
		if(modeCounter >= attacksBeforeModeSwitch)
		{
			modeCounter = 0;
			//timer = -2;
			if (style == AttackStyle.Aim) 
			{
				style = AttackStyle.Spin;
				timer = -delayFromAimToSpin;
			}
			else
			{
				style = AttackStyle.Aim;
				timer = -delayFromSpinToAim;
			} 
		}
		if(modeCounter == attacksBeforeModeSwitch/2 && shotCounter >= attackNumberOfShots)
		{
			cannonS.ToggleRotationDirection();
		}
	}
    
    public void TakeDmg()
	{
		if (currentHP > 0) currentHP--;
			else
		{
			currentHP = 0;
			playerOrbit.SetActive(true);
			this.gameObject.SetActive(false);
		}
		animation.Play("TakeDmg");
		healthBar.ValueBossHealth((float)initHP, (float)currentHP);
	}

	private void Entrance()
	{
		this.entranceFinished = true;
        healthBar.gameObject.SetActive(true);
	}
}