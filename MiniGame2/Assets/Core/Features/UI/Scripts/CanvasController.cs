using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Image soundButton;
    public Sprite soundButtonOn, soundButtonOff;
    private bool soundButtonSwitch = false;
    public GameObject levelOnePopUpMenu, pauseMenu, tutoLevelMenu, endSceneCanvas;
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
        if(levelHighscore != null)
            levelHighscore.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void chooseLevelSceneLoad()
    {
        Application.LoadLevel("LevelChoosingSceneAW");
        if (endSceneCanvas != null)
            endSceneCanvas.SetActive(false);
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

    public void openLevelOneMenu()
    {
        levelOnePopUpMenu.SetActive(true);
    }

    public void closeLevelOneMenu()
    {
        levelOnePopUpMenu.SetActive(false);
        levelHighscore.enabled = false;
    }

    public void opentutoLevelMenu()
    {
        tutoLevelMenu.SetActive(true);
    }

    public void closetutoLevelMenu()
    {
        tutoLevelMenu.SetActive(false);
        levelHighscore.enabled = false;
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

    public void startTutoLevel()
    {
        Application.LoadLevel("levelTutorialRemake");
    }

    public void startLevelOne()
    {
        Application.LoadLevel("level01Remake");
    }

    public void startSceneLoad()
    {
        Application.LoadLevel("startSceneAW");
    }

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevelName);
        if(endSceneCanvas != null)
            endSceneCanvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void showLevelHighscore(string levelName)
    {
        levelHighscore.enabled = true;
        levelHighscore.text = LanguageManager.Instance.Get("Phrases/HighScore") + PlayerPrefs.GetInt("Highscore" + levelName);
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
