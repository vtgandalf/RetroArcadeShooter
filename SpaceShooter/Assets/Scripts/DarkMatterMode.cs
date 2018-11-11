using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMatterMode : MonoBehaviour {
	public GameObject backgroundNormal;
	public GameObject backgroundDark;
	public GameObject weaponBar;
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
			if (backgroundDark.activeSelf == true) DisableDark();
            if (backgroundNormal.activeSelf == false)
            {
				EnableNormal();
                darkMatterMode = false;
            }
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
        else if (Input.deviceOrientation == DeviceOrientation.PortraitUpsideDown)
        {         
			if (backgroundNormal.activeSelf == true) DisableNormal();
            if (backgroundDark.activeSelf == false)
            {
				EnableDark();
                darkMatterMode = true;
            }
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
	}

	private void EnableNormal()
	{
		backgroundNormal.SetActive(true);
		if (weaponBar.activeSelf == false) weaponBar.SetActive(true);
	}

	private void EnableDark()
	{
		backgroundDark.SetActive(true);
		if (weaponBar.activeSelf == true) weaponBar.SetActive(false);
	}

	private void DisableNormal()
	{
		backgroundNormal.SetActive(false);
	}

	public void DisableDark()
	{
		backgroundDark.SetActive(false);
	}

	public bool DarkMatterModeBool
	{
		get { return this.darkMatterMode; }
	}
}