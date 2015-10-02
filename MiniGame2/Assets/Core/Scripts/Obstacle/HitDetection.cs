﻿using UnityEngine;
using System.Collections;

public class HitDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    public float HitSafePeriod = 0.3f;
    public int AdrenalinePenalty = 30;
    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();

    }

    IEnumerator OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PlayerHolder")
        {
            if (collider.gameObject.GetComponent<PlayerBoost>().moveTowardsObject) {
                collider.gameObject.GetComponent<PlayerBoost>().BoostHit();
                Destroy(gameObject);
            }
            else { 
                adrenalineController.DecreaseAdrenaline(AdrenalinePenalty);
                collider.enabled = false;
                yield return new WaitForSeconds(HitSafePeriod);
                collider.enabled = true;
            }
        }
    }
}
