using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public Player player;
	public float speed;
	private float step;
	float xDif, yDif, minX, minY, maxX, maxY;
	Vector3 pos;



	// Use this for initialization
	void Start () {
		step = speed * Time.deltaTime;
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
		if(Input.touchCount > 0)
		{
			pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			if(Input.GetTouch(0).phase == TouchPhase.Began)
			{
				print("Pos " + pos);
				xDif = player.transform.localPosition.x - pos.x;
				yDif = player.transform.localPosition.y - pos.y;
			}
			if(Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Vector3 newPos = new Vector3(xDif + pos.x, yDif + pos.y, 0);
				if (newPos.x < minX) newPos.x = minX;
				if (newPos.y < minY) newPos.y = minY;
				if (newPos.x > maxX) newPos.x = maxX;
                if (newPos.y > maxY) newPos.y = maxY;            
				player.transform.localPosition = newPos;
			}
		}







        //Correct translation
		/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            print("Touch Screen : " + Input.GetTouch(0).position);
            Vector3 Pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			player.transform.localPosition = new Vector3(Pos.x, Pos.y, 0);
            print("Pos " + Pos);
        }*/




			//this works kind of
			/*Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
			Vector2 playerNewPosition = new Vector2((player.transform.position.x + touchDeltaPosition.x), (player.transform.position.y + touchDeltaPosition.y));
			player.transform.position = Vector2.MoveTowards(player.transform.position, playerNewPosition, step);*/

			//second try
	}
}
