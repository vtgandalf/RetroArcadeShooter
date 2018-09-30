using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjManager : MonoBehaviour {
	
	public Transform projSpawn;
	//public Player player;
	GameObject entity;
	Player player;
	Enemy enemy;
	public bool enemyFire;
	public float shotSpeed;
	private float time = 0.0f;
    public float interpolationPeriod = 0.3f;
	public AudioManager audioManager;
	public Projectile projPrefab;
    // Use this for initialization
    void Start()
    {
		entity = this.gameObject;
		if (entity.GetComponent<Player>() != null)
        {
			player = entity.GetComponent<Player>();
        }
        else if (entity.GetComponent<Enemy>() != null)
        {
			enemy = entity.GetComponent<Enemy>();
        }

		//FireRate();
		//Fire();
    }
    
    // Update is called once per frame
    void Update()
    {   
		if (player != null)
		{
			if (player.Fire == true) FireRate();
		}
		else if (enemy != null && enemyFire )
		{
			FireRate();
		}
    }
   
	void Fire()
    {
        // Create the Bullet from the Bullet Prefab
		var missile = (Projectile)Instantiate(projPrefab,projSpawn.position,projSpawn.rotation);
        // Add velocity to the bullet
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,1f) * shotSpeed;

		// Destroy the bullet after 2 seconds
		//Destroy(missile, 5.0f);

		//play fire sound
		audioManager.PlayGun();
    }

    void FireRate()
	{      
        if (time >= interpolationPeriod)
        {
            time = 0.0f;

			Fire();
        }
		time += Time.deltaTime;
	}
}
