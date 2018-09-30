using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FunctionTypes
{
    DarkMatter, Weapon
}

public class PickUp : MonoBehaviour {

    private bool seen = false;
    private AudioManager audioManager;
	public FunctionTypes type;
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
        if (layer == LayerMask.NameToLayer("PickUps"))
        {
			Player player = col.gameObject.GetComponent<Player>();
			if (player != null)
            {
                if (audioManager != null) audioManager.PlayHit();
                Destroy(this.gameObject);
				if (type == FunctionTypes.DarkMatter) player.IncrementMass(1f);
                if (type == FunctionTypes.Weapon) player.IncrementFireRate();
       
                //Destroy(col.gameObject);
                //Debug.Log("player");
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
