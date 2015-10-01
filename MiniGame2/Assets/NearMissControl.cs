using UnityEngine;
using System.Collections;

public class NearMissControl : MonoBehaviour {


    private Transform elephantREF;
    // Use this for initialization
    void Start () {

        elephantREF = GameObject.FindGameObjectWithTag("Player").transform;

        GetComponent<TextMesh>().text = "Close One!!!";

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void NearMiss()
    {
        transform.position = elephantREF.position;
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0f, 180f, 0f);
        
    }

}
