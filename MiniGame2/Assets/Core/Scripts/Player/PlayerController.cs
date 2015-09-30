using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool RotateLeft, RotateRight = false; 

	public Animator RotateAnim;
	public Transform Middle, LeftPos, RightPos;
	public float MoveSpeed = 0.5f;
	public float StartSpeed;
	// Use this for initialization

	public float additionSpeed = 0.1f;

	void Start () {
		StartSpeed = MoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(!RotateLeft && !RotateRight)
		{
			//MoveFromTo(transform, Middle, MoveSpeed);
			RotateAnim.SetBool("TurnRight", false);
			RotateAnim.SetBool("TurnLeft", false);
		}
		else if(RotateLeft)
		{
			//MoveFromTo(transform, LeftPos, MoveSpeed);
			MoveSpeed += additionSpeed;
			transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
			RotateAnim.SetBool("TurnRight", false);
			RotateAnim.SetBool("TurnLeft", true);
		}
		else if(RotateRight)
		{
			MoveSpeed += additionSpeed;
			//MoveFromTo(transform, RightPos, MoveSpeed);
			transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
			RotateAnim.SetBool("TurnLeft", false);
			RotateAnim.SetBool("TurnRight", true);

		}

		if (Input.GetKeyDown (KeyCode.Escape))
		{
			Application.LoadLevel(Application.loadedLevel);
		}


	}

	void MoveFromTo(Transform from, Transform to, float speed)
	{
		transform.position = Vector3.Lerp(from.transform.position, to.transform.position, speed * Time.deltaTime);
		//transform.rotation = Quaternion.Lerp(from.transform.rotation, to.transform.rotation, speed * Time.deltaTime);
	}

}
