﻿using UnityEngine;
using System.Collections;

public class NearMissDetection : MonoBehaviour {

    private AdrenalineController adrenalineController;
    private NearMissControl nearMissControl;
    public int AdrenalineAwarded = 10;
	private AudioManager audioMngr;
    // Use this for initialization
    void Start () {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();
        nearMissControl = GameObject.FindGameObjectWithTag("NearMissText").GetComponent<NearMissControl>();
		audioMngr = GameObject.FindObjectOfType<AudioManager> ();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
			audioMngr.NearMissPlay();
            adrenalineController.IncreaseAdrenaline(AdrenalineAwarded);
            nearMissControl.NearMiss();
        }
    }
}
