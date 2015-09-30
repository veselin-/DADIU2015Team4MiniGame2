using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public bool RotateLeft, RotateRight = false; 

	public Animator RotateAnim;
	public Transform Middle, LeftPos, RightPos;
	public float MoveSpeed = 0.5f;
	// Use this for initialization
	void Start () {
	
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
			transform.Translate(Vector3.left * Time.deltaTime * MoveSpeed);
			RotateAnim.SetBool("TurnRight", false);
			RotateAnim.SetBool("TurnLeft", true);
		}
		else if(RotateRight)
		{
			//MoveFromTo(transform, RightPos, MoveSpeed);
			transform.Translate(Vector3.right * Time.deltaTime * MoveSpeed);
			RotateAnim.SetBool("TurnLeft", false);
			RotateAnim.SetBool("TurnRight", true);

		}

	}

	void MoveFromTo(Transform from, Transform to, float speed)
	{
		transform.position = Vector3.Lerp(from.transform.position, to.transform.position, speed * Time.deltaTime);
		//transform.rotation = Quaternion.Lerp(from.transform.rotation, to.transform.rotation, speed * Time.deltaTime);
	}

}
