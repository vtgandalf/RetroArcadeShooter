using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private float x, y, z;
	private bool seen = false;
    // Use this for initialization
    void Start()
    {
        z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
		UpdateRotation();
		OffScreenCheck();
    }

    public float Z
    {
        get { return this.z; }
        private set { this.z = value; }
    }

    public float X
    {
        get { return x; }
        private set { this.x = value; }
    }

    public float Y
    {
        get { return this.y; }
        private set { this.y = value; }
    }

    public void UpdatePos()
    {
        this.X = this.transform.localPosition.x;
        this.Y = this.transform.localPosition.y;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
		Debug.Log("collider");
		LayerMask layer = this.gameObject.layer;
		if(layer == LayerMask.NameToLayer("Enemy"))
		{
			if (col.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
				Destroy(this.gameObject);
                Destroy(col.gameObject);
                Debug.Log("player");
            }
		}
		if (layer == LayerMask.NameToLayer("Player"))
        {
            if (col.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
				Destroy(this.gameObject);
                Destroy(col.gameObject);
                Debug.Log("enemy");
            }
        }
        
    }

    void UpdateRotation()
	{
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
		Vector2 velocity = rb.velocity.normalized;
		float timeCount = Time.deltaTime;
		//Debug.Log(velocity);
		float rotationFactor = velocity.x*360;
        Debug.Log(rotationFactor);

		float currentRotZ = rb.transform.rotation.z;
		float currentRotX = rb.transform.rotation.x;
		float currentRotY = rb.transform.rotation.y;

		Quaternion target = Quaternion.Euler(0f, 0f, rotationFactor);

		rb.transform.rotation = Quaternion.Slerp(transform.rotation, target, timeCount);
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
