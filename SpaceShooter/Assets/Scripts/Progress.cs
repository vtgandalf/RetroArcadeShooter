using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Bar
{
	Mass, Weapon, BossHealth
}

public class Progress : MonoBehaviour
{

    Image foregroundImage;
	public Bar bar;
	private GameObject indicatorSingle;
	private GameObject indicatorDouble;
	private GameObject indicatorTripple;
	private GameObject indicatorQuad;
	private GameObject labelSingle;
	private GameObject labelDouble;
	private GameObject labelTripple;
	private GameObject labelQuad;
	private Animator animatorSingle;
	private Animator animatorDouble;
	private Animator animatorTripple;
	private Animator animatorQuad;
    
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
    
	public void ValueBossHealth(float initHP, float currentHP)
    {      
		if (foregroundImage != null)
			foregroundImage.fillAmount = currentHP/initHP;
    }

    void Start()
    {
		if (bar == Bar.Weapon)
        {
            this.indicatorSingle = this.gameObject.transform.GetChild(0).gameObject;
            this.indicatorDouble = this.gameObject.transform.GetChild(1).gameObject;
            this.indicatorTripple = this.gameObject.transform.GetChild(2).gameObject;
            this.indicatorQuad = this.gameObject.transform.GetChild(3).gameObject;
			this.labelSingle = this.indicatorSingle.transform.GetChild(0).gameObject;
			this.labelDouble = this.indicatorDouble.transform.GetChild(0).gameObject;
			this.labelTripple = this.indicatorTripple.transform.GetChild(0).gameObject;
			this.labelQuad = this.indicatorQuad.transform.GetChild(0).gameObject;
			this.animatorSingle = this.labelSingle.GetComponent<Animator>();
			this.animatorDouble = this.labelDouble.GetComponent<Animator>();
			this.animatorTripple = this.labelTripple.GetComponent<Animator>();
			this.animatorQuad = this.labelQuad.GetComponent<Animator>();
			this.indicatorDouble.SetActive(false);
			this.indicatorTripple.SetActive(false);
			this.indicatorQuad.SetActive(false);
        }
        foregroundImage = gameObject.GetComponent<Image>();      
        Value = 0;
		if (bar == Bar.BossHealth) Value = 100;
    }
    
	public void WeaponLevelIndicator( WeaponLevel level)
	{
		switch (level)
        {
			case WeaponLevel.Single:
				this.indicatorSingle.SetActive(true);
                this.animatorSingle.SetBool("exit", false);
				this.indicatorDouble.SetActive(false);
				this.indicatorTripple.SetActive(false);            
                this.animatorQuad.SetBool("exit", true);    
				this.indicatorQuad.SetActive(false);            
                break;
			case WeaponLevel.Dual:
				this.indicatorDouble.SetActive(true); 
                this.animatorDouble.SetBool("exit", false);       
                this.animatorSingle.SetBool("exit", true);
                break;
			case WeaponLevel.Tripple:
				this.indicatorTripple.SetActive(true);
                this.animatorTripple.SetBool("exit", false);
                this.animatorDouble.SetBool("exit", true);
                break;
			case WeaponLevel.Quad:
				this.indicatorQuad.SetActive(true);
                this.animatorQuad.SetBool("exit", false);
                this.animatorTripple.SetBool("exit", true);
                break;
        }
	}
}