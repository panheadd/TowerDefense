using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeTrigger : MonoBehaviour
{
    public List<Unit> units = new List<Unit>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddUnit(Unit unit)
    {
        if (!units.Contains(unit))
            units.Add(unit);
    }

    public void AddUnit3(Unit3 unit)
    {
        if (!units.Contains(unit))
    {
        units.Add(unit);
        unit.setRangeTrigger(this);
        unit.units = units;
        unit.buffUnits();
    }
    }

    public void RemoveUnit(Unit unit)
    {
        units.Remove(unit);
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy == null) return;

        foreach (Unit unit in units)
        {
            unit.AddEnemy(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();
        if (enemy == null) return;

        foreach (Unit unit in units)
        {
            unit.RemoveEnemy(enemy);
        }
    }
}
