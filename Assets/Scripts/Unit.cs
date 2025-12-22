using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
        public List<EnemyMovement> enemiesInRange = new List<EnemyMovement>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
