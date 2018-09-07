using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpace : MonoBehaviour {
	private MeshRenderer mr;
	private Material mat;
	private Vector2 offset;
	public float speed;
	// Use this for initialization
	/*void Start () {
		mr = GetComponent<MeshRenderer>();
		mat = mr.material;      
	}*/

	// Update is called once per frame
	void Update () {
		mr = GetComponent<MeshRenderer>();
        mat = mr.material;
		offset = mat.mainTextureOffset;
		offset.y += Time.deltaTime/speed;
        mat.mainTextureOffset = offset;
	}
}
