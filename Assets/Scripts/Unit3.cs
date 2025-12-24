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
        base.Update();
    }

    public void setRangeTrigger(RangeTrigger rangeTrigger)
    {
        this.rangeTrigger = rangeTrigger;
    }

    public void buffUnits()
    {
        foreach (Unit unit in units)
        {
            if (unit == this) continue;

            if (!unit.buff.activeSelf)
            {
                unit.buff.SetActive(true);
                unit.attackRate *= 0.5f;
            }
        }
    }

}
