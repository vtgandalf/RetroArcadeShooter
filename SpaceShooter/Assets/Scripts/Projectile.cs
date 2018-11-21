using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private bool seen = false;
	private AudioManager audioManager;
	public DarkMatterMode mode;
	public ObjectsManager objectsManager;
	// Use this for initialization
	void Start()
	{
		if(mode != null && objectsManager != null) objectsManager.AddOjbToList(this.gameObject);
		if(objectsManager != null) this.gameObject.GetComponent<Attractor>().objectsManager = objectsManager;
		//Debug.LogError(this.gameObject.GetComponent<Attractor>());
		audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
        if(mode != null && mode.DarkMatterModeBool == true)
		{
			this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
			this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
		}
	}

	// Update is called once per frame
	void FixUpdate()
	{
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//Debug.Log("collider");
		LayerMask layer = this.gameObject.layer;
		if (layer == LayerMask.NameToLayer("Enemy"))
		{
			if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				if (audioManager != null) audioManager.PlayHit();
				Destroy(this.gameObject);
				Destroy(col.gameObject);
			}
		}
		if (layer == LayerMask.NameToLayer("Player"))
		{
			if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				if (audioManager != null) audioManager.PlayHit();
				Destroy(this.gameObject);
				Destroy(col.transform.parent.gameObject);
			}
			if(col.gameObject.layer == LayerMask.NameToLayer("Boss"))
			{
				Boss boss = col.transform.GetComponent<Boss>();
				if (boss != null)
				{
					Destroy(this.gameObject);
					if(boss.EntranceDone) boss.TakeDmg();
				}
				//else Debug.LogError("boss not detected");
			}
		}
		if (layer == LayerMask.NameToLayer("BossProj"))
		{
			if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                if (audioManager != null) audioManager.PlayHit();
                Destroy(this.gameObject);
                Destroy(col.gameObject);
            }
		}
		if (col.gameObject.tag == "border")
        {
            Destroy(gameObject);
        }
	}

	void OnDestroy()
    {
		if (mode != null && objectsManager != null) objectsManager.RemoveObjFromList(this.gameObject);
    }
}