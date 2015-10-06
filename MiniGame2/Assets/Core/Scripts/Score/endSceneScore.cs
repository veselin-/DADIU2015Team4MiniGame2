using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endSceneScore : MonoBehaviour {
    public Text highscore, showCurrentScore;

    // Use this for initialization
    void Start () {
        if (ScoreControl.CurrentScore > PlayerPrefs.GetInt("Highscore"+ Application.loadedLevelName))
        {
            PlayerPrefs.SetInt("Highscore" + Application.loadedLevelName, ScoreControl.CurrentScore);
        }
        highscore.text = LanguageManager.Instance.Get("Phrases/HighScore") + PlayerPrefs.GetInt("Highscore"+ Application.loadedLevelName);
        showCurrentScore.text = LanguageManager.Instance.Get("Phrases/Score") + ScoreControl.CurrentScore;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
