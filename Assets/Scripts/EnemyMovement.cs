using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   public float speed = 2f;
    private GameObject waypoint;
    private Transform[] waypoints;
    private int waypointIndex = 0;
    private Animator animator;


    void Start()
    {
        waypoints = waypoint.GetComponentsInChildren<Transform>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        Move();
    }


    public void SetWaypoint(GameObject wp)
    {
        waypoint = wp;
    }
    void Move()
{
    if (waypointIndex >= waypoints.Length) return;

    Transform target = waypoints[waypointIndex];
    Vector3 dir = target.position - transform.position;

    animator.SetBool("Bool", true);

    if (dir != Vector3.zero)
    {
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            lookRotation,
            5f * Time.deltaTime
        );
    }

    transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

    if (Vector3.Distance(transform.position, target.position) < 0.2f)
    {
        waypointIndex++;
    }
}

}
