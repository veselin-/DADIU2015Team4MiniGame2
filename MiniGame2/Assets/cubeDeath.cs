using UnityEngine;
using System.Collections;

public class cubeDeath : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
        if (col.tag == "Player")
        {
            Application.LoadLevel("gameOverSceneAW");
        }
	}
}
