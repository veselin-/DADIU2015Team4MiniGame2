using UnityEngine;
using System.Collections;

public class NearMissDetectionCont : MonoBehaviour {

    private AdrenalineController adrenalineController;
    public int AdrenalineAwarded = 2;
    public float UpdateFrequency = 1;
    private float lastDamage;

    // Use this for initialization
    void Start()
    {
        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            lastDamage += Time.deltaTime;
            if (lastDamage >= UpdateFrequency)
            {
                lastDamage = 0;
                adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
            }
        }
    }
}
