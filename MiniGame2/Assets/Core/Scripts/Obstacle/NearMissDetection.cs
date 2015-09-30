using UnityEngine;
using System.Collections;

public class NearMissDetection : MonoBehaviour {


    private AdrenalineController adrenalineController;
    public int AdrenalineAwarded = 3;

    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerStay(Collider other)
    {
        adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
    }

}
