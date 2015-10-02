using UnityEngine;
using System.Collections;

public class cubeDeath : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		Application.LoadLevel ("gameOverSceneAW");
	}
}
