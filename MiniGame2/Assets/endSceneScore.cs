using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class endSceneScore : MonoBehaviour {
    public Text highscore, showCurrentScore;
    // Use this for initialization
    void Start () {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore" + Application.loadedLevelName);
        showCurrentScore.text = "Current score: " + ScoreControl.CurrentScore;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
