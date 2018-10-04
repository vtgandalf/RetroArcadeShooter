using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public PickUpManager pickUpManager;
	// Use this for initialization
	public WeaponLevel weaponLevel = WeaponLevel.Single;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
    {
		pickUpManager.Spawn();
    }

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "border")
        {
            Destroy(gameObject);
        }
	}

	public WeaponLevel WeaponLevel
	{
		get { return this.weaponLevel; }
	}
}
