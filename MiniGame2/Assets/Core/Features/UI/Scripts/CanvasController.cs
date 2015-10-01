using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    public Image soundButton;
    public Sprite soundButtonOn, soundButtonOff;
    private bool soundButtonSwitch = false;
    public GameObject levelPopUpMenu, pauseMenu;
	// Use this for initialization
	void Start () {
	
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
        if (soundButtonSwitch == false)
        {
            soundButton.sprite = soundButtonOff;
            soundButtonSwitch = true;
        }
        else
        {
            soundButton.sprite = soundButtonOn;
            soundButtonSwitch = false;
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

    public void startLevel()
    {
        Application.LoadLevel("inGameSceneAW");
    }

    public void startSceneLoad()
    {
        Application.LoadLevel("startSceneAW");
    }

    public void restartLevel()
    {
        Application.LoadLevel("inGameSceneAW");
        Time.timeScale = 1;
    }
}
