using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialResume : MonoBehaviour
{

    public Text TextBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Resume()
    {
        TextBox.enabled = false;
        Time.timeScale = 1f;
    }

}
