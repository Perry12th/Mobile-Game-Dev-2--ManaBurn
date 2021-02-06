using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTower : TowerBase
{

    private void Start()
    {
       Collider[] hits = Physics.OverlapSphere(transform.position, towerRange, enemyLayers);

        if (hits.Length > 0)
        {
            EnemyTarget = hits[0].gameObject;
        }

    }

    protected override void Fire()
    {
        if (EnemyTarget)
        {
            var newProjectile = Instantiate(projectile, sapwnPoint);

            newProjectile.GetComponent<UnityProjectile>().SetTarget(EnemyTarget);
        }
    }
}
