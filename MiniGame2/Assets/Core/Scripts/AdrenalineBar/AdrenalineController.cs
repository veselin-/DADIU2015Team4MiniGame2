using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AdrenalineController : MonoBehaviour {

    public Slider AdrenalineBar;

    private GameObject player;

    private Renderer[] rend;

    private Collider[] coll;

    public GameObject endSceneCanvas;

	// Use this for initialization
	void Start () {
        AdrenalineBar.value = 75f;

	    player = GameObject.FindGameObjectWithTag("Player");

        rend = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Renderer>();
        coll = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Collider>();
    }
	
    public void DecreaseAdrenaline(float amount)
    {
        AdrenalineBar.value -= amount;
        if (AdrenalineBar.value < 1)
        {

            player.GetComponent<PlayerBoost>().playerIsDead = true;

            foreach (Collider c in coll)
            {

                c.enabled = false;

            }

            foreach (Renderer r in rend)
            {

                r.enabled = false;

            }

            endSceneCanvas.SetActive(true);

            // Application.LoadLevel("gameOverSceneAW");
        }
    }

    public void IncreaseAdrenaline(float amount)
    {
        AdrenalineBar.value += amount;
    }
}
