using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitIndicator : MonoBehaviour
{

	private LineRenderer line;
	private int segments;
    private float xradius;
    private float yradius;

    void Start()
    {
		line = gameObject.GetComponent<LineRenderer>();
		segments = 20;
		line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePoints();
    }


    public void CreatePoints()
    {
        float x;
        float y;
        float z = 0f;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;

            line.SetPosition(i, new Vector3(x, y, z));

            angle += (360f / segments);
        }
    }

	public float Xradius
	{
		get { return this.xradius; }
		set { this.xradius = value; }
	}

	public float Yradius
    {
        get { return this.yradius; }
		set { this.yradius = value; }
    }
}