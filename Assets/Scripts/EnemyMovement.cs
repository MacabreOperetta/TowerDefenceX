using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int wavepointIndex = 0;

    private Enemy enemy;
    // Use this for initialization
    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {

            GetNextWaypoint();

        }
        enemy.speed = enemy.startspeed;
    }
    void GetNextWaypoint()
    {


        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }
        if (Waypoints.array[wavepointIndex].Equals("D"))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Waypoints.array[wavepointIndex].Equals("U"))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Waypoints.array[wavepointIndex].Equals("L"))
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
        }

        if (Waypoints.array[wavepointIndex].Equals("R"))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
        }
        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.lives--;
        Wave.enemiesalive--;
        Destroy(gameObject);

    }
}
