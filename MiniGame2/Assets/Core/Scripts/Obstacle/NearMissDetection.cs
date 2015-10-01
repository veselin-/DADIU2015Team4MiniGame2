using UnityEngine;
using System.Collections;

public class NearMissDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    public int AdrenalineAwarded = 10;

    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();

	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
        }
    }
}
