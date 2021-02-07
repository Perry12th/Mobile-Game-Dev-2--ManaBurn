using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTower : TowerBase
{
    [SerializeField]
    Transform towerBase;

    private void Start()
    {
       Collider[] hits = Physics.OverlapSphere(transform.position, towerRange, enemyLayers);

        if (hits.Length > 0)
        {
            EnemyTarget = hits[0].gameObject;
        }

        InvokeRepeating(nameof(Fire), 0, rateOfFire);

    }

    private void Update()
    {
        if (EnemyTarget)
        {
            towerBase.LookAt(new Vector3(EnemyTarget.transform.position.x, 0, EnemyTarget.transform.position.z));
            
        }
    }

    protected override void Fire()
    {
        if (EnemyTarget)
        {
            var newProjectile = Instantiate(projectile, sapwnPoint.position, Quaternion.identity);

            newProjectile.GetComponent<UnityProjectile>().SetTarget(EnemyTarget);
        }
    }
}
