using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviourClass : MonoBehaviour {

	public bool startedDoubleTap;
    public float timeSinceFirstTap;

    public float TapInterval = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    public bool Tap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Ended)
        {
            //startedDoubleTap = true;
            return true;
        }
        return false;
    }


    public bool DoubleTap()
    {
        if (Input.touchCount == 0) return false;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Ended)
        {
            if (startedDoubleTap)
            {
                if (timeSinceFirstTap < TapInterval)
                {
                    startedDoubleTap = false;
                    timeSinceFirstTap = 0;
                    return true;
                }
            }
            else
            {
                startedDoubleTap = true;
                return false;
            }
        }

        return false;

    }

    // Update is called once per frame
    void Update()
    {
        if (startedDoubleTap)
        {
            timeSinceFirstTap += Time.deltaTime;
            if (timeSinceFirstTap > TapInterval)
            {
                timeSinceFirstTap = 0;
                startedDoubleTap = false;
            }
        }

        if (Input.touchCount == 0) return;
        Touch touch = Input.GetTouch(0);


    }
}
