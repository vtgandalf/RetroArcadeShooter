using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour {
	private List<GameObject> objects;
	private List<GameObject> spritesNormal;
	private List<GameObject> spritesDark;
	private List<Attractor> attractors;
	public DarkMatterMode mode;
	private bool playMode;
	private bool lastPlayMode;
	// Use this for initialization
	void Start () {
		objects = new List<GameObject>();
		spritesNormal = new List<GameObject>();
		spritesDark = new List<GameObject>();
		attractors = new List<Attractor>();
		playMode = mode.DarkMatterModeBool;
		lastPlayMode = playMode;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.LogError(attractors.Count);
		ModeChangeCheck();
	}

	public List<Attractor> Attractors
	{
		get { return this.attractors; }
	}

	public void AddOjbToList(GameObject obj)
	{
		objects.Add(obj);
		spritesNormal.Add(obj.transform.GetChild(0).gameObject);
		spritesDark.Add(obj.transform.GetChild(1).gameObject);
	}

	public void RemoveObjFromList(GameObject obj)
	{
		objects.Remove(obj);
		spritesNormal.Remove(obj.transform.GetChild(0).gameObject);
        spritesDark.Remove(obj.transform.GetChild(1).gameObject);
	}

	public void AddObjToAttractors(Attractor attractor)
	{
		attractors.Add(attractor);
	}

	public void RemoveObjFromAttractors(Attractor attractor)
	{
		attractors.Remove(attractor);
	}

    private void ModeChangeCheck()
	{
		playMode = mode.DarkMatterModeBool;
		if(playMode != lastPlayMode)
		{
			switch (playMode)
            {
                case true:
					foreach(GameObject x in spritesNormal)
					{
						if (x.activeSelf == true) x.SetActive(false);
					}
					foreach(GameObject x in spritesDark)
					{
						if (x.activeSelf == false) x.SetActive(true);
					}
                    break;
                case false:
					foreach (GameObject x in spritesNormal)
                    {
                        if (x.activeSelf == false) x.SetActive(true);
                    }
                    foreach (GameObject x in spritesDark)
                    {
                        if (x.activeSelf == true) x.SetActive(false);
                    }
                    break;
            }
			lastPlayMode = playMode;
		}
	}
}
