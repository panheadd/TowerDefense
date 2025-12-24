using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3 : Unit
{
    private RangeTrigger rangeTrigger;
    public List<Unit> units;


    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

    }

    // Update is called once per frame
    protected override void Update()
    {
        units = rangeTrigger.units;
        buffUnits();



       if (isAttacking) return;

        enemiesInRange.RemoveAll(e => e == null || e.isDead);
        if (enemiesInRange.Count == 0)
            return;

        currentTarget = GetRandomEnemy();
        RotateTowardsTarget();

        if (Time.time >= nextAttackTime)
        {
            StartCoroutine(AttackCoroutine());
            nextAttackTime = Time.time + attackRate;
        }
    }

    public void setRangeTrigger(RangeTrigger rangeTrigger)
    {
        this.rangeTrigger = rangeTrigger;
    }

    public void buffUnits()
    {
        foreach (Unit unit in units)
    {
        if (unit == null) continue;        // Unit yok
        if (unit == this) continue;        // Kendini bufflama
        if (unit.buff == null) continue;   // Buff objesi yok
        if(unit.buffed == true)
            {
                continue;
            }

        if (!unit.buff.activeSelf)
        {
            unit.buffed = true;
            unit.buff.SetActive(true);
            unit.attackRate *= 0.5f;
        }
    }
    }

}
