using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdrenalineController : MonoBehaviour {

    public Slider AdrenalineBar;

	// Use this for initialization
	void Start () {

        AdrenalineBar.value = 100;
	}
	
    public void DecreaseAdrenaline(float amount)
    {
        AdrenalineBar.value -= amount;
    }

    public void IncreaseAdrenaline(float amount)
    {
        AdrenalineBar.value += amount;
    }
}
