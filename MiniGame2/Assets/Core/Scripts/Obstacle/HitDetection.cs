using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    public float HitSafePeriod = 0.3f;
    public int AdrenalinePenalty = 6;
    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator OnTriggerEnter(Collider collider)
    {
        adrenalineController.DecreaseAdrenaline(AdrenalinePenalty);
        collider.enabled = false;
        yield return new WaitForSeconds(HitSafePeriod);
        collider.enabled = true;
        
    }
}
