using UnityEngine;
using System.Collections;

public class PointTextControl : MonoBehaviour
{

    private Transform elephantREF;
	// Use this for initialization
	void Start ()
	{

	    elephantREF = GameObject.FindGameObjectWithTag("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
	
        

	}

    public void GotPoints(int points)
    {
        transform.position = elephantREF.position;
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0f, 180f, 0f);
        GetComponent<TextMesh>().text = points.ToString();
    }

}
