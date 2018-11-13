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
