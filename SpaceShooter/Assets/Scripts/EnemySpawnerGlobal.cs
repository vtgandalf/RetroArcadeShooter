using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerGlobal : MonoBehaviour {
	private int nrOfEnemiesSpawned;
	public DarkMatterMode mode;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void IncrementNrOfEnemyesSpawned()
	{
		this.nrOfEnemiesSpawned++;
	}

    public int NrOfEnemiesSpawned
	{
		get { return this.nrOfEnemiesSpawned; }
	}
}