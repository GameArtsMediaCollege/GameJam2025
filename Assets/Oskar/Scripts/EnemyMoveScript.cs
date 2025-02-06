using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoveScript : MonoBehaviour
{
    public int speedEnemy;

    [SerializeField] Transform currentTarget;
    [SerializeField] GameObject waypointObj;
    [SerializeField] float alertRange;
    [SerializeField] float attackInterval;
    [SerializeField] float attackRange;
    GameObject player;
    bool followingPlayer = false;
    bool movingTo = true;
    bool isAttacking = false;

    private void Awake()
    {
        //Assign waypoint variable
        waypointObj = GameObject.Find("Waypoints");
        player = GameObject.Find("Player");

        SetWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        float step = speedEnemy * Time.deltaTime;

        //Move to object if not already attacking player
        if (movingTo)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);
        }
        //Check if target is reached (only works for waypoints)
        CheckIfTargetIsReached();
        CheckDistanceToPlayer();
    }

    void CheckIfTargetIsReached()
    {
        if (transform.position == currentTarget.position)
        {
            SetWaypoint();
        }
    }

    void CheckDistanceToPlayer()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance <= alertRange && !followingPlayer)
        {
            followingPlayer = true;
            currentTarget = player.transform;
        }
        if (distance <= attackRange && !isAttacking)
        {
            Debug.Log("in attack range");
            Attack();
        }
    }

    void SetWaypoint()
    {
        //Pick random waypoint
        List<Transform> targets = waypointObj.GetComponent<WaypointScript>().waypoints;
        int listPos = Random.Range(0, targets.Count);
        Debug.Log(listPos);

        currentTarget = targets[listPos];
    }
    void Attack()
    {
        StartCoroutine(WaitBeforeMoving());
    }


    IEnumerator WaitBeforeMoving()
    {
        movingTo = false;
        isAttacking = true;
        yield return new WaitForSeconds(attackInterval);
        isAttacking = false;

        Debug.Log("move again");
        movingTo = true;

        SetWaypoint();

    }
}
