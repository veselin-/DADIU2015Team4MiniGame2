using UnityEngine;
using System.Collections;

public class endScene : MonoBehaviour {

    GameObject CameraHolder = null;
    public float cameraSpeedEnd = 5;
    Vector3 endPos;
    private bool smoothEnd = false;
    private bool lookUp = false;
    float t;
    Vector3 startPos;
    public float rotationAmount = 90.0f;

    void Start()
    {
        CameraHolder = GameObject.Find("CameraHolder");
        endPos = transform.GetChild(0).position;
    }

    void FixedUpdate()
    {
        if (smoothEnd)
        {
            t += Time.deltaTime / cameraSpeedEnd;
            CameraHolder.transform.position = Vector3.Lerp(startPos, endPos, t);
            if(Vector3.Distance(CameraHolder.transform.position, endPos) < 1)
            {
                smoothEnd = false;
                lookUp = true;
            }
        }

        if (lookUp)
        {
            Vector3 rot = CameraHolder.transform.rotation.eulerAngles;
            rot.x = rot.x - rotationAmount * Time.deltaTime;
            CameraHolder.transform.eulerAngles = rot;

            if(CameraHolder.transform.eulerAngles.x == 270)
            {
            

            }


        }

    }



    void OnTriggerEnter(Collider col)
	{
        if (col.tag == "Player")
        {
            CameraHolder.transform.parent = null;
            CameraHolder.GetComponent<SmoothFollow>().enabled = false;
            startPos = CameraHolder.transform.position;
            t = 0;
            smoothEnd = true;
        }
	}

}
