using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
	public Rigidbody2D rb;
	private float orbitSpeed = 0f;
	public ObjectsManager objectsManager;

	void Start()
	{
		objectsManager.AddObjToAttractors(this);
	}
	// Update is called once per frame
	void FixedUpdate()
	{
		foreach (Attractor attractor in objectsManager.Attractors)
		{
			if (attractor != this)
			{
				Attract(attractor);
			}
		}
	}

	void Attract(Attractor objToAttract)
	{
		Rigidbody2D rbToAttract = objToAttract.rb;
		if(orbitSpeed == 0f) orbitSpeed = rbToAttract.velocity.magnitude;
		Vector2 direction = rb.position - rbToAttract.position;
		float distance = direction.magnitude;
		//Debug.Log(distance);

		float forceMagnitude = (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
		Vector2 force = direction.normalized * forceMagnitude;

		if (this.GetComponent<Player>() != null)
		{
			if (distance > this.GetComponent<Player>().OrbitRange && objToAttract.gameObject.layer != 9)
			{
				rbToAttract.AddForce(force);
			}
			else if (this.GetComponent<Player>().orbit == true && objToAttract.gameObject.layer != 11)
			{
				objToAttract.gameObject.layer = 9;
				objToAttract.gameObject.transform.SetParent(transform);
				Transform trns = objToAttract.transform;
				Orbit(trns, orbitSpeed);
				rbToAttract.velocity = new Vector2(0f, 0f);
			}
			else if (objToAttract.gameObject.layer == 9)
			{
				AfterOrbit(rbToAttract, orbitSpeed);
			}
		}
	}

	void Orbit(Transform target, float speed)
	{      
		target.RotateAround(transform.position, new Vector3(0, 0, 1), speed);
	}


	void AfterOrbit(Rigidbody2D rbToAttract, float speed)
	{
		float trigY = rb.position.y - rbToAttract.position.y;
		float trigX = rb.position.x - rbToAttract.position.x;
		if ((trigY > 0 && trigY < 0.05) && trigX < 0)
		{
			rbToAttract.velocity = new Vector2(0, 1f) * speed;
			if (rbToAttract.gameObject.GetComponent<Attractor>())
			{
				rbToAttract.gameObject.GetComponent<Attractor>().enabled = false;
				rbToAttract.gameObject.transform.parent = null;
			}
		}
		else if (rbToAttract.gameObject.GetComponent<Attractor>().enabled != false) Orbit(rbToAttract.transform, speed);      
	}

	void OnDestroy()
    {
		objectsManager.RemoveObjFromAttractors(this);
    }
}