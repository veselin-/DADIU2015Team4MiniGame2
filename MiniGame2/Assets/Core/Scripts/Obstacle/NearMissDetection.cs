using UnityEngine;
using System.Collections;

public class NearMissDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    private NearMissControl nearMissControl;
    public int AdrenalineAwarded = 10;

    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();
        nearMissControl = GameObject.FindGameObjectWithTag("NearMissText").GetComponent<NearMissControl>();

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
            nearMissControl.NearMiss();
        }
    }
}
