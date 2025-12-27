using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public List<EnemyMovement> enemiesInRange = new List<EnemyMovement>();

    public float attackRate = 5f;
    protected float nextAttackTime = 0f;

    protected Animator animator;
    protected bool isAttacking = false;

    public GameObject projectilePrefab;   
    protected Transform firePoint;

    public float rotateSpeed = 8f;
    protected EnemyMovement currentTarget;
    private SoundManager soundManager;
    public GameObject buff;
    public bool buffed = false;

    protected virtual void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponentInChildren<Animator>();
        firePoint = transform.Find("FireBallPoint");
    }

    protected virtual void Update()
    {
        if (isAttacking) return;

        enemiesInRange.RemoveAll(e => e == null || e.isDead);
        if (enemiesInRange.Count == 0)
            return;

        currentTarget = enemiesInRange[0];
        RotateTowardsTarget();

        if (Time.time >= nextAttackTime)
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

    protected virtual IEnumerator AttackCoroutine()
    {
        // tower  adam sayısı al bunu 
        // listeye bak 
        // listedeye yeteri kadar 
        isAttacking = true;

        int count = 0;
        EnemyMovement target = null;
        foreach (EnemyMovement enemyPossible in enemiesInRange)
        {
            // ittarate isTargeted unit false
            target = enemiesInRange[count];
            if (target.isTargeted)
            {
                count++;
                continue;
            }
            // null stage
            if (target == null)
            {
                enemiesInRange.RemoveAt(0);
                isAttacking = false;
                yield break;
            }
            
            //success stage
            if( enemyPossible.isTargeted == false) break;
        }
        if ( target != null) target.isTargeted = true;
        
        animator.SetTrigger("Attack");

        yield return new WaitForSeconds(0.5f);

        SpawnProjectile(target);   // kritik nokta

        isAttacking = false;
    }

    // override edilecek method
    protected virtual void SpawnProjectile(EnemyMovement target)
    {
        GameObject proj = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        proj.GetComponent<Fireball>().SetTarget(target);
        soundManager.PlayFireBallSound();
    }

    protected void RotateTowardsTarget()
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

    protected EnemyMovement GetRandomEnemy()
{
    if (enemiesInRange.Count == 0)
        return null;

    int index = Random.Range(0, enemiesInRange.Count);
    return enemiesInRange[index];
}
}
