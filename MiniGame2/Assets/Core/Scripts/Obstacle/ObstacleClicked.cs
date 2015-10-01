using UnityEngine;
using System.Collections;

public class ObstacleClicked : MonoBehaviour {


    private PlayerBoost playerBoost;


	// Use this for initialization
	void Start () {


        playerBoost = GameObject.FindGameObjectWithTag("Player").transform.parent.GetComponent<PlayerBoost>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnMouseDown()
    {
        playerBoost.MoveTowardsObstacle(this.transform.position, Input.mousePosition);
           
    }
}
