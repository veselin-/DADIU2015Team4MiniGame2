using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Image soundButton;
    public Sprite soundButtonOn, soundButtonOff;
    private bool soundButtonSwitch = false;
    public GameObject levelPopUpMenu, pauseMenu;
    public Text levelHighscore;
	// Use this for initialization
    void Awake()
    {
        //PlayerPrefs.SetString("Sound", "On");
    }
    
	void Start () {
        if (PlayerPrefs.GetString("Sound").Equals("On"))
        {
            //PlayerPrefs.SetString("Sound", "On");
            if (soundButton != null)
            {
                soundButton.sprite = soundButtonOn;
            }
            AudioListener.pause = false;
        }
        else if (PlayerPrefs.GetString("Sound").Equals("Off"))
        {
            //PlayerPrefs.SetString("Sound", "Off");
            if (soundButton != null)
            {
                soundButton.sprite = soundButtonOff;
            }
            AudioListener.pause = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void chooseLevelSceneLoad()
    {
        Application.LoadLevel("LevelChoosingSceneAW");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundOnOrOff()
    {
        if (PlayerPrefs.GetString("Sound").Equals("On"))
        {
            PlayerPrefs.SetString("Sound", "Off");
            soundButton.sprite = soundButtonOff;
            AudioListener.pause = true;
        }
        else
        {
            PlayerPrefs.SetString("Sound", "On");
            AudioListener.pause = false;
            soundButton.sprite = soundButtonOn;
        }

        //     if (soundButtonSwitch == false)
        //     {
        //         soundButton.sprite = soundButtonOff;
        //AudioListener.pause = true;
        //         soundButtonSwitch = true;
        //     }
        //     else
        //     {
        //         soundButton.sprite = soundButtonOn;
        //AudioListener.pause = false;
        //         soundButtonSwitch = false;
        //     }
    }

    public void openLevelMenu()
    {
        levelPopUpMenu.SetActive(true);
    }

    public void closeLevelMenu()
    {
        levelPopUpMenu.SetActive(false);
    }

    public void openPauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void closePauseMenu()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void startLevel()
    {
		Application.LoadLevel("levelTutorial");
    }

    public void startSceneLoad()
    {
        Application.LoadLevel("startSceneAW");
    }

    public void restartLevel()
    {
        Application.LoadLevel("levelTutorial");
        Time.timeScale = 1;
    }

    public void showLevelHighscore()
    {
        levelHighscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }
}
