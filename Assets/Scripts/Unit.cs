using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public List<EnemyMovement> enemiesInRange = new List<EnemyMovement>();
    public float attackRate = 5f;
    private float nextAttackTime = 0f;
    private Animator animator;
    private bool isAttacking = false;
    public GameObject fireballPrefab;
    private Transform firePoint;

    public float rotateSpeed = 8f;
    private EnemyMovement currentTarget;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        firePoint = transform.Find("FireBallPoint");
        
    }

    void Update()
    {
        if (isAttacking) return;

    
        enemiesInRange.RemoveAll(e => e == null || e.isDead);
        if (enemiesInRange.Count == 0)
            return;


        currentTarget = enemiesInRange[0];
        RotateTowardsTarget();

        if (!isAttacking && Time.time >= nextAttackTime)
        {
            StartCoroutine(AttackCoroutine());
            nextAttackTime = Time.time + attackRate;
        }
        
    }

    public void AddEnemy(EnemyMovement enemy)
    {
        if (!enemiesInRange.Contains(enemy))
            enemiesInRange.Add(enemy);
    }

    public void RemoveEnemy(EnemyMovement enemy)
    {
        enemiesInRange.Remove(enemy);
    }

    public EnemyMovement GetFirstEnemy()
    {
        if (enemiesInRange.Count == 0) return null;
        return enemiesInRange[0];
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        EnemyMovement target = enemiesInRange[0];
        if (target == null)
        {
            enemiesInRange.RemoveAt(0);
            isAttacking = false;
            yield break;
        }

        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.5f);

        SpawnFireball(target);

        isAttacking = false;
    }

    void SpawnFireball(EnemyMovement target)
    {
        GameObject fb = Instantiate(
            fireballPrefab,
            firePoint.position,
            firePoint.rotation
        );

        fb.GetComponent<Fireball>().SetTarget(target);
    }

    void RotateTowardsTarget()
{
    if (currentTarget == null) return;

    Vector3 dir = currentTarget.transform.position - transform.position;
    dir.y = 0f; 

    if (dir == Vector3.zero) return;

    Quaternion targetRot = Quaternion.LookRotation(dir);
    transform.rotation = Quaternion.Slerp(
        transform.rotation,
        targetRot,
        rotateSpeed * Time.deltaTime
    );
}


}
