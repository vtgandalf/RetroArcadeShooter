using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private float x, y, z;
    // Use this for initialization
    void Start()
    {
        z = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePos();
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
}
