using UnityEngine;
using System.Collections;

public class ScoreControl : MonoBehaviour
{


    public int CurrentScore;


	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddPoints(int points)
    {

        CurrentScore += points;

        if (CurrentScore > PlayerPrefs.GetInt("Highscore"))
        {

            PlayerPrefs.SetInt("Highscore", CurrentScore);
        }
      

    }

}
