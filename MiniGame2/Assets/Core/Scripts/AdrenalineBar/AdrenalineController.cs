using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdrenalineController : MonoBehaviour {

    public Slider AdrenalineBar;

	// Use this for initialization
	void Start () {
        AdrenalineBar.value = 75f;
	}
	
    public void DecreaseAdrenaline(float amount)
    {
        AdrenalineBar.value -= amount;
        if (AdrenalineBar.value < 1)
        {
            Application.LoadLevel("gameOverSceneAW");
        }
    }

    public void IncreaseAdrenaline(float amount)
    {
        AdrenalineBar.value += amount;
    }
}
