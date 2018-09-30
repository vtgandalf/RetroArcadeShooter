using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private bool fire = false;
	public bool orbit = false;
	private float orbitRange;
	Rigidbody2D rb;

    public ProjManager projManager;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		OrbitRange = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float OrbitRange
	{
		get { return this.orbitRange; }
		set { this.orbitRange = value; }
	}

	public bool Fire
    {
        get { return this.fire; }
        set { this.fire = value; }
    }

    public void IncrementMass(float step)
	{
		if (rb != null)
		{
			rb.mass = rb.mass + step;
			OrbitRange += 0.05f;
			Debug.Log("mass was increased");
		}
		else Debug.Log("mass was not increased");
	}
    
    public void IncrementFireRate(float step)
	{
		projManager.interpolationPeriod = projManager.interpolationPeriod - step;
	}
}
