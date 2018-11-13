using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int nrOfEnemiesBeforeBoss;
	public EnemySpawnerGlobal spawnerGlobal;
	public DarkMatterMode mode;
	public Boss boss;
	public GameObject rotateIndicator;
	public float timeBeforeBoss;
	private float timer;

	public GameObject player;
    public GameObject enemySpawner;
    public GameObject levelUI;
    public GameObject controlsUI;
    
	public void StartLevelSingleFingerMode()
	{
		StartLevel(MovementStyle.SingleFInger);
	}

	public void StartLevelDualFingerMode()
    {
		StartLevel(MovementStyle.TwoFinger);
    }

	private void StartLevel(MovementStyle movementStyle)
    {
        controlsUI.SetActive(false);
        player.SetActive(true);
		Movement movement = player.GetComponent<Movement>();
		if (movement != null) movement.movementStyle = movementStyle;      
        levelUI.SetActive(true);
        enemySpawner.SetActive(true);
    }

	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnerGlobal.NrOfEnemiesSpawned >= nrOfEnemiesBeforeBoss)
		{
			if (spawnerGlobal.gameObject.activeSelf == true ) spawnerGlobal.gameObject.SetActive(false);
			//if (rotateIndicator.activeSelf == false) rotateIndicator.SetActive(true);
		}
		if(spawnerGlobal.gameObject.activeSelf == false)
		{
			timer += Time.deltaTime;
			if(timer >= timeBeforeBoss)
			{
				if (rotateIndicator.activeSelf == false) rotateIndicator.SetActive(true);
                if (mode.DarkMatterModeBool == true)
				{
					if (rotateIndicator.activeSelf == true) rotateIndicator.SetActive(false);
					boss.gameObject.SetActive(true);
				}
			}
		}
	}
}
