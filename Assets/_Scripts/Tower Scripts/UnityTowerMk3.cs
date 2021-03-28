using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTowerMk3 : TowerBase
{
    [SerializeField]
    Transform towerBase;
    [SerializeField]
    Transform spawnPoint2;

    private void Awake()
    {
        type = TowerTypes.UnityMk3;
    }
    private void Start()
    {
        InvokeRepeating(nameof(Fire), 0, rateOfFire);

    }

    private void Update()
    {
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

    public override TowerSave Save()
    {
        TowerSave save = new TowerSave();
        save.towerID = SaveManager.instance.saveDatabase.GetTowerID[type];
        save.towerPosition = new float[] { transform.position.x, transform.position.y, transform.position.z };
        save.towerRotation = new float[] { towerBase.transform.rotation.x, towerBase.transform.rotation.y, towerBase.transform.rotation.z };
        return save;
    }

    public override void Load(TowerSave save)
    {
        Vector3 newPosition = new Vector3(save.towerPosition[0], save.towerPosition[1], save.towerPosition[2]);
        Vector3 newRotation = new Vector3(save.towerRotation[0], save.towerRotation[1], save.towerRotation[2]);
        transform.position = newPosition;
        towerBase.transform.eulerAngles = newRotation;
    }
}
