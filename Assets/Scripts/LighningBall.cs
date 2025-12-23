using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighningBall : MonoBehaviour
{
    public float speed = 8f;
    private EnemyMovement target;

    public void SetTarget(EnemyMovement enemy)
    {
        target = enemy;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = (target.transform.position - transform.position).normalized;
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy != null && enemy == target)
        {
            enemy.DieByLightning();
            Destroy(gameObject);
        }
    }
}
