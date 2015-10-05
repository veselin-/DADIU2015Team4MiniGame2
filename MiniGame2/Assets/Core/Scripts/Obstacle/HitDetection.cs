﻿using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    public float HitSafePeriod = 0.3f;
    public int AdrenalinePenalty = 30;
	private AudioManager audioMngr;
    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();
		audioMngr = GameObject.FindObjectOfType<AudioManager> ();
    }

    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            if (collider.gameObject.GetComponent<PlayerBoost>().moveTowardsObject) {
                collider.gameObject.GetComponent<PlayerBoost>().BoostHit();
                Destroy(transform.parent.parent.gameObject);
            }
            else {
                audioMngr.FailPlay();
                adrenalineController.DecreaseAdrenaline(AdrenalinePenalty);
                collider.enabled = false;
                yield return new WaitForSeconds(HitSafePeriod);
                collider.enabled = true;
            }
        }
    }
}
