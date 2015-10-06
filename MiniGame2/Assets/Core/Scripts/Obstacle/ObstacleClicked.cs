﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ObstacleClicked : MonoBehaviour {


    private PlayerBoost playerBoost;


	// Use this for initialization
	void Start () {
        playerBoost = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBoost>();
        if(playerBoost == null)
            Debug.LogError("Cannot find boost controller");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        // Makes sure you cannot boost through the canvas
        if (EventSystem.current.IsPointerOverGameObject())
            return; 

        Debug.Log("CLicked!");
        var transPos = this.transform.position;
        playerBoost.MoveTowardsObstacle(transPos);

    }
}
