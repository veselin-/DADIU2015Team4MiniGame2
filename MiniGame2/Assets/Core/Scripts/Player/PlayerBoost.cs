using UnityEngine;
using System.Collections;

public class PlayerBoost : MonoBehaviour
{

    public float speed = 10;
    public bool moveTowardsObject;
    private bool moveBack;
    private Vector3 targetPosition;
    public float MaxDistanceToObstacle = 100;
    public float MinDistanceToObstacle = 50;
    public float MinAdrenalin;
    private AdrenalineController adrenalineController;
    private float _oldSpeed = 0;

    private Vector3 tPos;

    // Use this for initialization
    void Start()
    {

        adrenalineController = GameObject.FindGameObjectWithTag("UI").GetComponent<AdrenalineController>();
        if(adrenalineController == null)
            Debug.LogError("Cannot find adrenalineController");
    }

    // Update is called once per frame
    void Update()
    {
        if (moveTowardsObject) { 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed*Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, targetPosition) <= 1) { 
            moveBack = true;
        }
        if (transform.localPosition.Equals(Vector3.zero))
        {
            moveBack = false;
        }
        if (moveBack)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, Vector3.zero, speed*Time.deltaTime);
        }
    }

    public void BoostHit()
    {
        moveBack = true;
        moveTowardsObject = false;
    }


    public void MoveTowardsObstacle(Vector3 position)
    {
        // We need some amount of adrenaline to do this
        if (adrenalineController.AdrenalineBar.value < MinAdrenalin)
            return;

        //The cosine of the angle between the two vectors, it will be positive if the target position is in front of the player
        Vector3 heading = position - transform.position;
        float dot = Vector3.Dot(heading, transform.forward);

        if (dot < MaxDistanceToObstacle && dot > MinDistanceToObstacle)
        {
            moveTowardsObject = true;
            targetPosition = new Vector3(position.x, this.transform.position.y, position.z);
            adrenalineController.DecreaseAdrenaline(25f);
        }
    }
}



