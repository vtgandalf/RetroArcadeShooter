using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Bar
{
	Mass, Weapon
}

public class Progress : MonoBehaviour
{

    Image foregroundImage;
	public Player player;
	public Bar bar;
    
    public int Value
    {
        get
        {
            if (foregroundImage != null)
                return (int)(foregroundImage.fillAmount * 100);
            else
                return 0;
        }
        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value / 100f;
        }
    }

    void Start()
    {
        foregroundImage = gameObject.GetComponent<Image>();
        Value = 0;
    }

    void Update()
	{
		if (player != null)
		{
			if (bar == Bar.Mass) Value = player.MassProgressCounter;
			if (bar == Bar.Weapon) Value = player.WeaponProgressCounter;         
		}
	}
}
