using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementStyle{
	TwoFinger, SingleFInger
}

public class Movement : MonoBehaviour {

	public Player player;
	public OrbitActivation orbit;
	float xDif, yDif, minX, minY, maxX, maxY;
	Vector3 pos;
	private float tapTimer;
	public MovementStyle movementStyle;
       
	// Use this for initialization
	void Start () {
		tapTimer = 0f;
		Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
		Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
		minX = lowerLeft.x;
		minY = lowerLeft.y;
		maxX = upperRight.x;
		maxY = upperRight.y;
	}

	// Update is called once per frame
	void Update()
	{
		switch(movementStyle)
		{
			case MovementStyle.SingleFInger:
				MovementStyle2();
				break;
			case MovementStyle.TwoFinger:
				MovementStyle1();
				break;
		}
	}

    private void MovementStyle1()
	{
		if (Input.touchCount > 0)
        {
            pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                xDif = player.transform.localPosition.x - pos.x;
                yDif = player.transform.localPosition.y - pos.y;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 newPos = new Vector3(xDif + pos.x, yDif + pos.y, 0);
                if (newPos.x < minX) newPos.x = minX;
                if (newPos.y < minY) newPos.y = minY;
                if (newPos.x > maxX) newPos.x = maxX;
                if (newPos.y > maxY) newPos.y = maxY;
                player.transform.localPosition = newPos;
            }
            if (Input.touchCount == 2)
            {
                if (orbit.Trig)
                {
                    player.orbit = true;
                }
                if (!player.orbit) player.Fire = true;
            }
            if (Input.touchCount == 1)
            {
                xDif = player.transform.localPosition.x - pos.x;
                yDif = player.transform.localPosition.y - pos.y;
                player.Fire = false;
                player.orbit = false;
                orbit.Trig = false;
                return;
            }
        }
	}

    private void MovementStyle2()
	{
		if (Input.touchCount > 0)
        {
			tapTimer += Time.deltaTime;
            pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                xDif = player.transform.localPosition.x - pos.x;
                yDif = player.transform.localPosition.y - pos.y;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                Vector3 newPos = new Vector3(xDif + pos.x, yDif + pos.y, 0);
                if (newPos.x < minX) newPos.x = minX;
                if (newPos.y < minY) newPos.y = minY;
                if (newPos.x > maxX) newPos.x = maxX;
                if (newPos.y > maxY) newPos.y = maxY;
                player.transform.localPosition = newPos;
            }
			if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
				if(tapTimer <= 0.5f)
				{
					if (orbit.Trig)
                    {
						player.orbit =! player.orbit;
                    }
					if (!player.orbit) player.Fire =! player.Fire;
				}
				tapTimer = 0f;
            }
        }
	}

}
