using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class EnemyMoveScript : MonoBehaviour
{
    public int speedEnemy;

    [SerializeField] Transform currentTarget;
    [SerializeField] GameObject waypointObj;



    private void Start()
    {
        //Assign waypoint variable
        waypointObj = GameObject.Find("Waypoints");

        //Pick random waypoint
        List<Transform> targets = waypointObj.GetComponent<WaypointScript>().waypoints;
        int listPos = Random.Range(0, targets.Count);
        Debug.Log(listPos);

        currentTarget = targets[listPos];
    }


    // Update is called once per frame
    void Update()
    {
        var step = speedEnemy * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, step);

        if(transform.position == currentTarget.position)
        {
            SetWaypoint();
        }
    }

    void SetWaypoint()
    {

    }
    void Death()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
