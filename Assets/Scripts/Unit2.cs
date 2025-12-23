using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit2 : Unit
{
    protected override void Start()
    {
        base.Start();
        firePoint = transform.Find("LightningBallPoint");
    }
    protected override void Update()
    {
        if (isAttacking) return;

        enemiesInRange.RemoveAll(e => e == null || e.isDead);
        if (enemiesInRange.Count == 0)
            return;

        RotateTowardsTarget();

        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(AttackCoroutine());
            nextAttackTime = Time.time + attackRate;
        }
    }
   protected override void SpawnProjectile(EnemyMovement target)
    {
        GameObject lightning = Instantiate(
            projectilePrefab,
            firePoint.position,
            firePoint.rotation
        );

        SoundManager.Instance.PlayFireBallSound();
        lightning.GetComponent<LighningBall>().SetTarget(target);
    }

    protected override IEnumerator AttackCoroutine()
{
    isAttacking = true;

    EnemyMovement target = GetRandomEnemy();
    if (target == null)
    {
        isAttacking = false;
        yield break;
    }

    currentTarget = target; // ⚠️ dönmesi için önemli
    RotateTowardsTarget();

    animator.SetTrigger("Attack");

    yield return new WaitForSeconds(0.5f);

    SpawnProjectile(target);

    isAttacking = false;
}



}
