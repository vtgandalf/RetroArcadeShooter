using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSpace : MonoBehaviour {
	private MeshRenderer mr;
	private Material mat;
	public BackgroundSynchManager synchManager;   
    public BackgroundTytpe type;
	private Vector2 offset;
	// Use this for initialization
	void Start () {
		mr = GetComponent<MeshRenderer>();
		mat = mr.material;
		OffsetSetup();      
        mat.mainTextureOffset = offset;
	}

	// Update is called once per frame
	void Update () {
		switch (type)
        {
            case BackgroundTytpe.Back:
                offset = synchManager.OffsetBack;
                break;
            case BackgroundTytpe.Fore:
                offset = synchManager.OffsetFore;
                break;
            case BackgroundTytpe.Mid:
                offset = synchManager.OffsetMid;
                break;
        }
        mat.mainTextureOffset = offset;
	}

    private void OffsetSetup()
	{
		switch (type)
        {
            case BackgroundTytpe.Back:
                offset = synchManager.OffsetBack;
                break;
            case BackgroundTytpe.Fore:
                offset = synchManager.OffsetFore;
                break;
            case BackgroundTytpe.Mid:
                offset = synchManager.OffsetMid;
                break;
        }
	}
}
