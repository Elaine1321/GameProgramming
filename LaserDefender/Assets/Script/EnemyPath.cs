using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour


{

[SerializeField] List<Transform> waypoints;

[SerializeField] float enemySpeed = 2f;

int waypointsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        if(waypointsIndex < waypoints.Count)
        {
            //set targetPosition to the next waypoint
            Vector3 TargetPosition= waypoints[waypointsIndex].transform.position;
            TargetPosition.z=0f;

            float movmentThisFrame = enemySpeed * Time.deltaTime;

            transform.position=Vector3.MoveTowards(transform.position,TargetPosition,movmentThisFrame);

            if(transform.position == TargetPosition)
            {
                waypointsIndex++;
            }

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
