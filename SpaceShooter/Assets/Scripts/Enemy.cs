using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public PickUpManager pickUpManager;
	public DarkMatterMode mode;
	public ObjectsManager objectsManager;
	// Use this for initialization
	public WeaponLevel weaponLevel = WeaponLevel.Single;
	void Start () {
		objectsManager.AddOjbToList(this.gameObject);
		if (mode.DarkMatterModeBool == true)
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy()
    {
		objectsManager.RemoveObjFromList(this.gameObject);
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
