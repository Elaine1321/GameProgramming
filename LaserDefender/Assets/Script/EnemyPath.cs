using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour


{

[SerializeField] List<Transform> waypoints;

[SerializeField] float enemySpeed = 2f;

[SerializeField] GameObject laserPrefab;
[SerializeField] float laserFiringTime;
[SerializeField] float laserSpeed = -10f;

int waypointsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointsIndex].transform.position;
    StartCoroutine(EnemyShoot());

    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    IEnumerator EnemyShoot()
    {
        //while to coroutine is running
        while(true)
        {
             GameObject laser= Instantiate(laserPrefab, transform.position, transform.rotation);
             laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0 , laserSpeed);

             laserFiringTime = Random.Range(0.5f, 1f);

             yield return new WaitForSeconds(laserFiringTime);
        }
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
