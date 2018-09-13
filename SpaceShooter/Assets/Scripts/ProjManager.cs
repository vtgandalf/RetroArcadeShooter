using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjManager : MonoBehaviour {
	public GameObject projPrefab;
	public Transform projSpawn;
	public Player player;
	public float shotSpeed;
	private float time = 0.0f;
    public float interpolationPeriod = 0.3f;
    // Use this for initialization
    void Start()
    {
		
    }
    
    // Update is called once per frame
    void Update()
    {
		FireRate();
		if (player != null)
		{
			if (player.Fire == true) FireRate();
		}
    }
   
	void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var missile = (GameObject)Instantiate(projPrefab,projSpawn.position,projSpawn.rotation);
        // Add velocity to the bullet
		missile.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,1f) * shotSpeed;

        // Destroy the bullet after 2 seconds
        Destroy(missile, 5.0f);
    }

    void FireRate()
	{
		time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = 0.0f;

			Fire();
        }
	}
}
