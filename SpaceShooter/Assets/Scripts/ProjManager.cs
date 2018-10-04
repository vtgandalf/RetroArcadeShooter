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
	public float weaponOffset = 0.25f;
	public float weaponAngle = 0.25f;
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
   
	void FireSingle()
    {
        // Create the Bullet from the Bullet Prefab
		var missile = (Projectile)Instantiate(projPrefab,projSpawn.position,projSpawn.rotation);
        // Add velocity to the bullet
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,1f) * shotSpeed;

		//play fire sound
		audioManager.PlayGun();
    }

	void FireDouble()
    {
		// Create the Bullet from the Bullet Prefab
		Vector3 positionLeft = new Vector3(projSpawn.position.x - weaponOffset, projSpawn.position.y, projSpawn.position.z);
		Vector3 positionRight = new Vector3(projSpawn.position.x + weaponOffset, projSpawn.position.y, projSpawn.position.z);
		var missileLeft = (Projectile)Instantiate(projPrefab, positionLeft, projSpawn.rotation);
		var missileRight = (Projectile)Instantiate(projPrefab, positionRight, projSpawn.rotation);
        // Add velocity to the bullet
        missileLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * shotSpeed;
		missileRight.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * shotSpeed;      
        //play fire sound
        audioManager.PlayGun();
    }

	void FireTripple()
    {
        // Create the Bullet from the Bullet Prefab
		Vector3 positionLeft = new Vector3(projSpawn.position.x - weaponOffset, projSpawn.position.y, projSpawn.position.z);
		Vector3 positionRight = new Vector3(projSpawn.position.x + weaponOffset, projSpawn.position.y, projSpawn.position.z);
        var missileMiddle = (Projectile)Instantiate(projPrefab, projSpawn.position, projSpawn.rotation);
		var missileLeft = (Projectile)Instantiate(projPrefab, positionLeft, projSpawn.rotation);
        var missileRight = (Projectile)Instantiate(projPrefab, positionRight, projSpawn.rotation);
        // Add velocity to the bullet
		missileLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(-weaponAngle, 1f) * shotSpeed;
        missileRight.GetComponent<Rigidbody2D>().velocity = new Vector2(weaponAngle, 1f) * shotSpeed;
		missileMiddle.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * shotSpeed;//play fire sound
        audioManager.PlayGun();
    }

	void FireQuad()
    {
        // Create the Bullet from the Bullet Prefab
        Vector3 positionLeft = new Vector3(projSpawn.position.x - weaponOffset, projSpawn.position.y, projSpawn.position.z);
        Vector3 positionRight = new Vector3(projSpawn.position.x + weaponOffset, projSpawn.position.y, projSpawn.position.z);
		Vector3 positionMidLeft = new Vector3(projSpawn.position.x - weaponOffset/2, projSpawn.position.y, projSpawn.position.z);
        Vector3 positionMidRight = new Vector3(projSpawn.position.x + weaponOffset/2, projSpawn.position.y, projSpawn.position.z);
        var missileMidLeft = (Projectile)Instantiate(projPrefab, projSpawn.position, projSpawn.rotation);
		var missileMidRight= (Projectile)Instantiate(projPrefab, projSpawn.position, projSpawn.rotation);
        var missileLeft = (Projectile)Instantiate(projPrefab, positionLeft, projSpawn.rotation);
        var missileRight = (Projectile)Instantiate(projPrefab, positionRight, projSpawn.rotation);
        // Add velocity to the bullet
        missileLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(-weaponAngle, 1f) * shotSpeed;
        missileRight.GetComponent<Rigidbody2D>().velocity = new Vector2(weaponAngle, 1f) * shotSpeed;
		missileMidLeft.GetComponent<Rigidbody2D>().velocity = new Vector2(-weaponAngle/4, 1f) * shotSpeed;
		missileMidRight.GetComponent<Rigidbody2D>().velocity = new Vector2(weaponAngle/4, 1f) * shotSpeed;
        audioManager.PlayGun();
    }

    void FireRate()
	{      
        if (time >= interpolationPeriod)
        {
            time = 0.0f;

			if (player != null)
			{
				if (player.WeaponLevel == WeaponLevel.Single) FireSingle();
                else if (player.WeaponLevel == WeaponLevel.Dual) FireDouble();
                else if (player.WeaponLevel == WeaponLevel.Tripple) FireTripple();  
				else if (player.WeaponLevel == WeaponLevel.Quad) FireQuad(); 
			}
			else if (enemy != null)
			{
				if (enemy.WeaponLevel == WeaponLevel.Single) FireSingle();
                else if (enemy.WeaponLevel == WeaponLevel.Dual) FireDouble();
				else if (enemy.WeaponLevel == WeaponLevel.Tripple) FireTripple();
				else if (enemy.WeaponLevel == WeaponLevel.Quad) FireQuad(); 
			}
        }
		time += Time.deltaTime;
	}
}
