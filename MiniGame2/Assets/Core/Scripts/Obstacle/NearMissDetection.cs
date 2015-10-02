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
            Debug.Log("NearMiss");
            StartCoroutine(NearMiss(other.gameObject));
        }
    }

    IEnumerator NearMiss(GameObject go)
    {
        yield return new WaitForSeconds(.1f);
        if (go.GetComponent<Collider>().enabled)
      {
            adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
            nearMissControl.NearMiss();
       }
        yield return null;
       
    }
}
