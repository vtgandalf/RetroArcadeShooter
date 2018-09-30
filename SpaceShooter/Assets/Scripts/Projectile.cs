using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	private bool seen = false;
	private AudioManager audioManager;
	// Use this for initialization
	void Start()
	{
		audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
		if (audioManager == null) Debug.Log("failed to assign audioManager");
		else Debug.Log("audioManager assigned");
	}

	// Update is called once per frame
	void Update()
	{
		OffScreenCheck();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
		//Debug.Log("collider");
		LayerMask layer = this.gameObject.layer;
		if(layer == LayerMask.NameToLayer("Enemy"))
		{
			if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
			{
				if (audioManager != null) audioManager.PlayHit();
				Destroy(this.gameObject);
                Destroy(col.gameObject);
                //Debug.Log("player");
            }
		}
		if (layer == LayerMask.NameToLayer("Player"))
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
			{
				if (audioManager != null) audioManager.PlayHit();
				Destroy(this.gameObject);
                Destroy(col.gameObject);
                //Debug.Log("enemy");
            }
        }
    }

	void OffScreenCheck()
    {
		Renderer renderer = this.gameObject.GetComponentInChildren<Renderer>();
        if (renderer.isVisible)
            seen = true;

        if (seen && !renderer.isVisible)
            Destroy(gameObject);
    }
}
