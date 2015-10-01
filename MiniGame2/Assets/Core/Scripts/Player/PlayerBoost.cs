using UnityEngine;
using System.Collections;

public class PlayerBoost : MonoBehaviour
{

    public float speed = 10;
    private bool moveTowardsObject = false;
    private Vector3 targetPosition;
    public float MaxDistanceToObstacle = 100;
    public float MinDistanceToObstacle = 50;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (moveTowardsObject)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) <= 1)
            {
                moveTowardsObject = false;
            }
        }
    }


    public void MoveTowardsObstacle(Vector3 position, Vector3 mousePosClicked)
    {
        //We use the y coordinate of the mouse vs the player because the obstacle always is in front of the player.
        float disPlayerAndMouseClick = Mathf.Abs(mousePosClicked.y - Camera.main.WorldToScreenPoint(transform.position).y);

        //We need to make sure that the distance is taken care of in both the screen and world distance.
        if (!moveTowardsObject && disPlayerAndMouseClick > MinDistanceToObstacle && disPlayerAndMouseClick < MaxDistanceToObstacle && Vector3.Distance(position, transform.position) < MaxDistanceToObstacle)
        {
            moveTowardsObject = true;
            targetPosition = new Vector3(position.x, this.transform.position.y, position.z);
        }
    }
}



