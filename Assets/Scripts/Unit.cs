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

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        firePoint = transform.Find("FireBallPoint");
        
    }

    void Update()
    {
        if (enemiesInRange.Count == 0)
            return;

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

        // animasyon sonrası
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


}
