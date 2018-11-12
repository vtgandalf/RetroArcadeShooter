using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public Transform projSpawn;
	public Enemy enemy;
	public float interpolationPeriod = 0.3f;
	public float timeOffset = 0f;
	private float time = 0.0f;
	public float speed;
	private EnemySpawnerGlobal parent;
	// Use this for initialization
	void Start () {
		time += timeOffset;
		parent = this.gameObject.GetComponentInParent<EnemySpawnerGlobal>();
	}
	
	// Update is called once per frame
	void Update () {
		SpawnRate();
	}
    
	public void Spawn ()
	{
		var unit = (Enemy)Instantiate(enemy, projSpawn.position, projSpawn.rotation);
		ProjManager projManager = unit.GetComponent<ProjManager>();
		projManager.mode = parent.mode;
		projManager.objectsManager = parent.objectsManager;
		unit.mode = parent.mode;
		unit.objectsManager = parent.objectsManager;
        //projectile.mode = parent.mode;
        // Add velocity to the bullet
        unit.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * speed;
		// add the unit to the list of obj
		//parent.objectsManager.AddOjbToList(unit.gameObject);
		//unit.GetComponent<SpriteManager>().mode = parent.mode;
		//unit.GetComponent<ProjManager>().projPrefab.GetComponent<SpriteManager>().mode = parent.mode;
        
		parent.IncrementNrOfEnemyesSpawned();
	}

	void SpawnRate()
    {
        if (time >= interpolationPeriod)
        {
            time = 0.0f;

            Spawn();
        }
        time += Time.deltaTime;
    }
}
