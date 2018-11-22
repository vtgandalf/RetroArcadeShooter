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
	public float weaponStep;
	public float darkMatterStep;
    // Use this for initialization
    void Start()
    {
        audioManager = (AudioManager)FindObjectOfType(typeof(AudioManager));
    }

    // Update is called once per frame
    void Update()
    {
		
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
				if (type == FunctionTypes.DarkMatter) 
				{
					//x2 only for demo
					player.IncrementMass(darkMatterStep);
					player.IncrementMass(darkMatterStep);
				}
				if (type == FunctionTypes.Weapon)
				{
					//x2 only for demo
					player.IncrementFireRate(weaponStep);
					player.IncrementFireRate(weaponStep);
				}
            }
        }
		if (col.gameObject.tag == "border")
        {
            Destroy(gameObject);
        }
    }
}
