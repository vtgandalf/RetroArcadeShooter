using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {
    
	public float TapInterval = 0.5f;
    private float timeSinceFirstTap;

    void Start()
    {
		
    }

    void Update()
    {
		/*timeSinceFirstTap += Time.deltaTime;
		if (timeSinceFirstTap < TapInterval)
		{         
            DoubleTap();
		}
		else
		{
            SingleTap();
			timeSinceFirstTap = 0;
		}*/
		timeSinceFirstTap += Time.deltaTime;
		if (!DoubleTap() && timeSinceFirstTap > TapInterval) SingleTap();
		else if (!SingleTap() && !DoubleTap()) timeSinceFirstTap = 0;
    }

    bool DoubleTap()
	{
		for (var i = 0; i < Input.touchCount; i++)
        {
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				if (Input.GetTouch(i).tapCount == 2)
				{
					Debug.Log("Double Tap");
					return true;
				}
			}
        }
		return false;
	}

    bool SingleTap()
	{
		for (var i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
				if (Input.GetTouch(i).tapCount == 1)
                {
                    Debug.Log("Single Tap");
					return true;
                }
            }
        }
		return false;
	}
}
