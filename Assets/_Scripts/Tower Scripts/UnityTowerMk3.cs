using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTowerMk3 : TowerBase
{
    [SerializeField]
    Transform towerBase;
    [SerializeField]
    Transform spawnPoint2;

    private void Start()
    {
        InvokeRepeating(nameof(Fire), 0, rateOfFire);

    }

    protected override void Update()
    {
        base.Update();
        EnemyTarget = GetClosestEnemy();

        if (EnemyTarget)
        {
            Vector3 targetDirection = EnemyTarget.transform.position - towerBase.transform.position;
            Vector3 newDirection = Vector3.RotateTowards(towerBase.transform.forward, targetDirection, 5.0f * Time.deltaTime, 0.0f);
            towerBase.transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    protected override void Fire()
    {

        if (EnemyTarget)
        {
            var enemyDirection = EnemyTarget.transform.position - towerBase.transform.position;
            enemyDirection.y = 0;
            var protectile1 = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
            protectile1.GetComponent<UnityAPProjectile>().SetTarget(EnemyTarget);
            var protectile2 = Instantiate(projectile, spawnPoint2.position, Quaternion.identity);
            protectile2.GetComponent<UnityAPProjectile>().SetTarget(EnemyTarget);
            turretSFX.Play();
        }
    }
}
