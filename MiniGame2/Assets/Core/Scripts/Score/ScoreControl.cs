using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{


    public int CurrentScore;

    public Text scoreField;

	// Use this for initialization
	void Start () {
	
        

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPoints(int points)
    {

        CurrentScore += points;

        scoreField.text = "Score: " + CurrentScore;

        if (CurrentScore > PlayerPrefs.GetInt("Highscore"))
        {

            PlayerPrefs.SetInt("Highscore", CurrentScore);

        }
      

    }

}
