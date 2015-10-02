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


    public void MoveTowardsObstacle(Vector3 position, Vector3 mousePosClicked)
    {
        // We need some amount of adrenaline to do this
        if (adrenalineController.AdrenalineBar.value < MinAdrenalin)
            return;

        

        //We use the y coordinate of the mouse vs the player because the obstacle always is in front of the player.
        float disPlayerAndMouseClick = Mathf.Abs(mousePosClicked.y - Camera.main.WorldToScreenPoint(transform.position).y);
        
        //We need to make sure that the distance is taken care of in both the screen and world distance.
        if (!moveTowardsObject && disPlayerAndMouseClick > MinDistanceToObstacle && disPlayerAndMouseClick < MaxDistanceToObstacle && Vector3.Distance(position, transform.position) < MaxDistanceToObstacle)
        {
            moveTowardsObject = true;
            targetPosition = new Vector3(position.x, this.transform.position.y, position.z);
            adrenalineController.DecreaseAdrenaline(25f);
        }
    }
}



