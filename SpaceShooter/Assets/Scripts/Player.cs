﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WeaponLevel
{
	Single, Dual, Tripple, Quad
}

public class Player : MonoBehaviour {
	public bool fire = false;
	public bool orbit = false;
	public Progress progressMassManager;
	public Progress progressWeaponManager;
    private int massProgressCounter;
	private int weaponProgressCounter;
	private float orbitRange;
	Rigidbody2D rb;
	public WeaponLevel weaponLevel;
	private float interpolationPeriodStore;

    public ProjManager projManager;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		OrbitRange = 0.5f;
		MassProgressCounter = 0;
		WeaponProgressCounter = 0;
		weaponLevel = WeaponLevel.Single;
		if (projManager != null) interpolationPeriodStore = projManager.interpolationPeriod;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public WeaponLevel WeaponLevel
	{
		get { return this.weaponLevel; }
	}

    public int MassProgressCounter
	{
		get { return this.massProgressCounter; }
		set 
		{
			if (value <= 100 && value >= 0) this.massProgressCounter = value;
			else if (value < 0) this.massProgressCounter = 0;
		}
	}

	public int WeaponProgressCounter
    {
        get { return this.weaponProgressCounter; }
        set 
		{ 
			if (value <= 100 && value >= 0) this.weaponProgressCounter = value;
            else if (value < 0) this.weaponProgressCounter = 0;
		}
    }

    public float OrbitRange
	{
		get { return this.orbitRange; }
		set { this.orbitRange = value; }
	}

	public bool Fire
    {
        get { return this.fire; }
        set { this.fire = value; }
    }

    public void IncrementMass(float step)
	{
		if (rb != null && MassProgressCounter < 100)
		{
			rb.mass = rb.mass + step;
			OrbitRange += 0.05f;
			MassProgressCounter += 10;
		}
		progressMassManager.Value = MassProgressCounter;
	}

	public void DecrementMass(float step)
    {
        if (rb != null && MassProgressCounter > 0)
        {
            rb.mass = rb.mass - step/2;
            OrbitRange -= 0.05f/2;
            MassProgressCounter -= 10/2;
        }
        progressMassManager.Value = MassProgressCounter;
    }
    
    public void IncrementFireRate(float step)
	{
		if (WeaponProgressCounter < 100)
		{
			projManager.interpolationPeriod = projManager.interpolationPeriod - step;
            WeaponProgressCounter += 10;
		}
		if (weaponProgressCounter == 100)
		{
			projManager.interpolationPeriod = interpolationPeriodStore;
			WeaponProgressCounter = 0;
			UpdateWeaponLevel();
		}
        progressWeaponManager.Value = WeaponProgressCounter;
	}

    void OnDestroy()
	{
		SceneManager.LoadScene("menuBase", LoadSceneMode.Single);
	}

    public void UpdateWeaponLevel()
	{
		Handheld.Vibrate();
		if (weaponLevel == WeaponLevel.Quad) weaponLevel = WeaponLevel.Single;
		else weaponLevel++;
		progressWeaponManager.WeaponLevelIndicator(WeaponLevel);
	}
}
