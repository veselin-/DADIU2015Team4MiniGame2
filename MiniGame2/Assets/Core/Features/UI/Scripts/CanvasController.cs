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
        if (!PlayerPrefs.HasKey("Language"))
        {
            PlayerPrefs.SetString("Language", "English");
            LanguageManager.Instance.LoadLanguage(PlayerPrefs.GetString("Language"));
        }
        else
        {
            LanguageManager.Instance.LoadLanguage(PlayerPrefs.GetString("Language"));
        }
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

    public void startLevelTuto()
    {
        Application.LoadLevel("levelTutorial");
    }

    public void startLevelOne()
    {
        Application.LoadLevel("levelOne");
    }

    public void startSceneLoad()
    {
        Application.LoadLevel("startSceneAW");
    }

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevelName);
        Time.timeScale = 1;
    }

    public void showLevelHighscore()
    {
        levelHighscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    public void languageChange(string language)
    {
        LanguageManager.Instance.LoadLanguage(language);
        PlayerPrefs.SetString("Language", language);
        LocalizedText[] texts = FindObjectsOfType<LocalizedText>();
        foreach (LocalizedText text in texts)
        {
            text.LocalizeText();
        }
    }
}
