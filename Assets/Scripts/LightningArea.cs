using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EnemyMovement enemy = other.GetComponent<EnemyMovement>();

        if (enemy == null) return;

        if (enemy.isDead) return;

        enemy.DieByLightningArea();
    }
}
