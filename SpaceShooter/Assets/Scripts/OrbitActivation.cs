using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitActivation : MonoBehaviour {
	public Player player;
	private bool trig;
	public OrbitIndicator orbitIndicator;
	// Use this for initialization
	void Start () {
		Trig = false;
		UpdateRange();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateRange();
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collider");
        LayerMask layer = this.gameObject.layer;
		if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
			Trig = true;
			player.Fire = false;
        }
		else
		{
			Trig = false;
		}
    }

    public bool Trig
	{
		get { return this.trig; }
		set { this.trig = value; }
	}

    public void UpdateRange ()
	{
		orbitIndicator.Xradius = player.OrbitRange;
		orbitIndicator.Yradius = player.OrbitRange;
		orbitIndicator.CreatePoints();
		transform.GetComponent<CircleCollider2D>().radius = player.OrbitRange;
	}
}
