using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {
	public Rigidbody2D rb;
	
	// Update is called once per frame
	void FixedUpdate () {
		Attractor[] attractors = FindObjectsOfType<Attractor>();
		foreach (Attractor attractor in attractors)
		{
			if (attractor != this)
			{
				Attract(attractor);
			}
		}
	}

	void Attract (Attractor objToAttract)
	{
		Rigidbody2D rbToAttract = objToAttract.rb;

		Vector2 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;
		//Debug.Log(distance);

		float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);      
		Vector2 force = direction.normalized * forceMagnitude;

		/*if(distance < 1.5)
		{
			rbToAttract.AddForce(force);
		}*/
		if (this.GetComponent<Player>() != null)
		{         
            rbToAttract.AddForce(force);
		}
	}
}