using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
	public int nrOfEnemiesBeforeBoss;
	public EnemySpawnerGlobal spawnerGlobal;
	public DarkMatterMode mode;
	public Boss boss;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnerGlobal.NrOfEnemiesSpawned >= nrOfEnemiesBeforeBoss)
		{
			spawnerGlobal.gameObject.SetActive(false);
		}
		if(spawnerGlobal.gameObject.activeSelf == false && mode.DarkMatterModeBool == true)
		{
			boss.gameObject.SetActive(true);
		}
	}
}
