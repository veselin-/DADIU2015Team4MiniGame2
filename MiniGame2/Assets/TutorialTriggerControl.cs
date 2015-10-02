using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TutorialTriggerControl : MonoBehaviour
{

    public Text TextBox;
   

    public string TutorialText;

	// Use this for initialization
	void Start ()
	{

	    TextBox.enabled = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {

            Time.timeScale = 0f;

            TextBox.text = TutorialText;
            
            

            TextBox.enabled = true;


        }        
    }

}
