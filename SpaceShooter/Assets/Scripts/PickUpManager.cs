using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour {
   
    private Transform pickUpSpawn;
    public float initSpeed;
    public AudioManager audioManager;
	public PickUp pickUpPrefabWeapon;
	public PickUp pickUpPrefabDarkMatter;
    // Use this for initialization
    void Start()
    {
		pickUpSpawn = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
		List<PickUp> picks = new List<PickUp>{pickUpPrefabWeapon, pickUpPrefabDarkMatter};
		System.Random rndm = new System.Random();
        // Create the pickUp from the prefab
		var pickUp = (PickUp)Instantiate(picks[rndm.Next(0,picks.Count)], pickUpSpawn.position, pickUpSpawn.rotation);
        // Add velocity to the object
		pickUp.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 1f) * initSpeed;
        audioManager.PlayGun();
    }
}
