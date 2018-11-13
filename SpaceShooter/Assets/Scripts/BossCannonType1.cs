using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannonType1 : MonoBehaviour {

	public Transform projSpawn;
    GameObject entity;
	public Player player;
    public float shotSpeed;
    public Projectile projPrefab;
	public ObjectsManager objectsManager;

	// Use this for initialization
	void Start () {
		entity = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FireSingleTowardsPlayer()
    {
        // Create the Bullet from the Bullet Prefab
        var missile = (Projectile)Instantiate(projPrefab, projSpawn.position, projSpawn.rotation);
		SetupObj(missile);
        // Aim towards the player      
		Vector2 direction = new Vector2(player.transform.position.x,player.transform.position.y) - new Vector2(projSpawn.position.x,projSpawn.position.y);
        // Add velocity to the bullet
		missile.GetComponent<Rigidbody2D>().velocity = direction * shotSpeed;
    }

    public void FireSingle()
	{
		var missile = (Projectile)Instantiate(projPrefab, projSpawn.position, projSpawn.rotation);
        SetupObj(missile);
		missile.GetComponent<Rigidbody2D>().velocity = projSpawn.right * shotSpeed;
	}

	private void SetupObj(Projectile proj)
    {
        proj.objectsManager = objectsManager;
    }
}