using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteManager : MonoBehaviour {
	private GameObject spriteNormal;
	private GameObject spriteDark;
	public DarkMatterMode mode;
	// Use this for initialization
	void Start () {
		spriteNormal = this.transform.GetChild(0).gameObject;
		spriteDark = this.transform.GetChild(1).gameObject;

	}
	
	// Update is called once per frame
	void Update () {
		switch(mode.DarkMatterModeBool)
		{
			case true:
				if (spriteNormal.activeSelf == true) spriteNormal.SetActive(false);
				if (spriteDark.activeSelf == false) spriteDark.SetActive(true);
				break;
			case false:
				if (spriteDark.activeSelf == true) spriteDark.SetActive(false);
				if (spriteNormal.activeSelf == false) spriteNormal.SetActive(true);
				break;
		}
	}
}
