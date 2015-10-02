using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	public AudioSource music;
	public AudioSource flapping;
	public AudioSource success;
	public AudioSource wind;
	public AudioSource fail;
	public AudioSource nearmiss;
	public AudioSource electrified;
	public AudioSource coins;
	public AudioSource buttonClick;
	public AudioSource hitGround;


	public AudioMixer MasterMixer;
	public AudioMixer MusicMixer;
	public AudioMixer SoundFXMixer;

	void Awake()
	{
		PlayerPrefs.SetString("Sound", "On");
		AudioListener.pause = false;
	}

	void Start()
	{
		//PlayerPrefs.GetString ("");
		if(!PlayerPrefs.HasKey("Sound"))
		{
			PlayerPrefs.SetString("Sound", "On");
			AudioListener.pause = false;
			//LanguageManager.Instance.LoadLanguage(PlayerPrefs.GetString ("Sound"));
		}


		if (PlayerPrefs.GetString ("Sound").Equals ("On")) {
			//PlayerPrefs.SetString("Sound", "Off");
			AudioListener.pause = false;
		} else
		{
			//PlayerPrefs.SetString("Sound", "On");
			AudioListener.pause = true;
		}
	}



	public void MusicPlay()
	{
		music.Play ();
	}

	public void MusicStop()
	{
		music.Stop ();
	}
	public void WindPlay()
	{
		wind.Play ();
	}
	public void WindStop()
	{
		wind.Stop ();
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
