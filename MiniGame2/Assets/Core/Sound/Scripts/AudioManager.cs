using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public AudioSource themeMusic;
	public AudioSource flapping;
	public AudioSource success;
	public AudioSource wind;
	public AudioSource fail;
	public AudioSource nearmiss;
	public AudioSource electrified;
	public AudioSource coins;
	public AudioSource buttonClick;
	public AudioSource hitGround;
    public AudioSource veselinPleaseDance;


	public AudioMixer MasterMixer;
	public AudioMixer MusicMixer;
	public AudioMixer SoundFXMixer;

	void Awake()
	{

	}

	void Start()
	{

	}

	public void ThemeMusicPlay()
	{
		themeMusic.Play ();
	}

	public void ThemeMusicStop()
	{
		themeMusic.Stop ();
	}
	public void WindPlay()
	{
		//wind.Play ();
        veselinPleaseDance.Play();
	}
	public void WindStop()
	{
		//wind.Stop ();
        veselinPleaseDance.Stop();
    }
	public void FlappingPlay()
	{
		flapping.Play ();
	}
	public void FlappingStop()
	{
		flapping.Stop ();
	}

	public void SuccessPlay()
	{
		success.Play ();
	}

	public void SuccessStop()
	{
		success.Stop ();
	}

	public void ChangeSuccessPitch(float pitch)
	{
		SoundFXMixer.SetFloat ("SuccessPitch", pitch);
	}


	public void FailPlay()
	{
		fail.Play ();
	}

	public void FailStop()
	{
		fail.Stop ();
	}

	public void NearMissPlay()
	{
		nearmiss.Play ();
	}
	
	public void NearMissStop()
	{
		nearmiss.Stop ();
	}

	public void ElectrifiedPlay()
	{
		electrified.Play ();
	}
	
	public void ElectrifiedStop()
	{
		electrified.Stop ();
	}

	public void CoinsPlay()
	{
		coins.Play ();
	}
	
	public void CoinsStop()
	{
		coins.Stop ();
	}
	
	public void HitGroundPlay()
	{
		hitGround.PlayDelayed(0.5f);
	}
	
	public void HitGroundStop()
	{
		hitGround.Stop ();
	}

	public void ButtonClickPlay()
	{
		buttonClick.Play ();
	}
	
	public void ButtonClickStop()
	{
		buttonClick.Stop ();
	}


}
