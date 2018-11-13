using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum RotationDirection{
	ClockWise, CounterCloclWise
}

public class BossSpinningCannon : MonoBehaviour {
	public BossCannonType1 cannon1;
	public BossCannonType1 cannon2;
	public BossCannonType1 cannon3;
	public BossCannonType1 cannon4;
	public float rotationSpeed;
	public float shotSpeed;
	public RotationDirection rotationDirection;
	public ObjectsManager objectsManager;
	// Use this for initialization
	void Start () {
		rotationDirection = RotationDirection.ClockWise;
		cannon1.shotSpeed = shotSpeed;
		cannon2.shotSpeed = shotSpeed;
		cannon3.shotSpeed = shotSpeed;
		cannon4.shotSpeed = shotSpeed;
		cannon1.objectsManager = objectsManager;
		cannon2.objectsManager = objectsManager;
		cannon3.objectsManager = objectsManager;
		cannon4.objectsManager = objectsManager;
	}
	
	// Update is called once per frame
	void Update () {
		SpinUpdate();
	}

    public void Fire()
	{
		cannon1.FireSingle();
		cannon2.FireSingle();
		cannon3.FireSingle();
		cannon4.FireSingle();
	}
    
    private void SpinUpdate()
	{
		switch (rotationDirection)
        {
            case RotationDirection.ClockWise:
                transform.Rotate(0, 0, rotationSpeed * (-Time.deltaTime));
                break;
            case RotationDirection.CounterCloclWise:
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
                break;
        }
	}

    public void ToggleRotationDirection()
	{
		switch(rotationDirection)
		{
			case RotationDirection.ClockWise:
				rotationDirection = RotationDirection.CounterCloclWise;
				break;
			case RotationDirection.CounterCloclWise:
				rotationDirection = RotationDirection.ClockWise;
				break;
		}
	}
}
