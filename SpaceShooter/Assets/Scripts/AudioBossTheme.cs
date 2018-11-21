using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBossTheme : MonoBehaviour {
	public AudioClip bossIntroIntro;
	public AudioClip bossIntroLoop;
	public AudioClip bossSecondIntro;
	public AudioClip bossSecondLoop;
	public AudioClip bossThirdIntro;
	public AudioClip bossThirdLoop;

	public AudioSource generalSource;

	public Boss boss;
	private int currentHP;
	private int startingHP;

	// Use this for initialization
	void Start () {
		SetUpHP();
	}
	
	// Update is called once per frame
	void Update () {
		SetUpHP();
		if(currentHP >= 65*startingHP/100)
		{
			PlaySegment(bossIntroIntro, bossIntroLoop);
		}
		else if(currentHP >= 45*startingHP/100)
		{
			PlaySegment(bossSecondIntro, bossSecondLoop);
		}
		else if(currentHP < 45*startingHP/100)
		{
			PlaySegment(bossThirdIntro, bossThirdLoop);
		}
	}

	private void PlaySegment(AudioClip intro, AudioClip loop)
	{
		if (generalSource.clip != loop) generalSource.loop = false;
        if (!generalSource.isPlaying)
        {
            if (generalSource.clip != intro)
            {
				generalSource.clip = intro;
                generalSource.Play();
            }
			else if (generalSource.clip == intro)
            {
                generalSource.loop = true;
				generalSource.clip = loop;
                generalSource.Play();
            }
        }
	}

    private void SetUpHP()
	{      
        currentHP = boss.CurrentHP;
        startingHP = boss.StartingHP;
	}
}
