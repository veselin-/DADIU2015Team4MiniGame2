using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{


    public static int CurrentScore;

    public Text scoreField;

    private GameObject pointTextREF;

    // Use this for initialization
    void Start () {
        pointTextREF = GameObject.FindGameObjectWithTag("PointText");

	}
	
	// Update is called once per frame
	void Update () {


	
	}

    public void AddPoints(int points)
    {

        CurrentScore += points;

        pointTextREF.GetComponent<PointTextControl>().GotPoints(points);

        scoreField.text = "Score: " + CurrentScore;

        if (CurrentScore > PlayerPrefs.GetInt("Highscore"+Application.loadedLevelName))
        {

            PlayerPrefs.SetInt("Highscore" + Application.loadedLevelName, CurrentScore);

        }
      

    }

}
