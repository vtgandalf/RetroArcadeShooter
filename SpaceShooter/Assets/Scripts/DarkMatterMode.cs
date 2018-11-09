using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatterMode : MonoBehaviour {
	public GameObject backgroundNormal;
	public GameObject backgroundDark;
	private bool darkMatterMode;
	// Use this for initialization
	void Start () {
		ScreenOrientationSetUp();
		darkMatterMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		ChangeMode();
	}

    private void ScreenOrientationSetUp()
	{
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = true;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}

    private void ChangeMode()
	{
		if (Input.deviceOrientation == DeviceOrientation.Portrait)
        {
			if (backgroundDark.activeSelf == true) backgroundDark.SetActive(false);
			if (backgroundNormal.activeSelf == false) 
			{
				backgroundNormal.SetActive(true);
				darkMatterMode = false;
			}
        }
        else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {
            if (backgroundNormal.activeSelf == true) backgroundNormal.SetActive(false);
			if (backgroundDark.activeSelf == false) 
			{
				backgroundDark.SetActive(true);
				darkMatterMode = true;
			}
        }
	}

	public bool DarkMatterModeBool
	{
		get { return this.darkMatterMode; }
	}
}
