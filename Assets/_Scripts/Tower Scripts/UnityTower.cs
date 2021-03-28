using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTower : TowerBase
{
    [SerializeField]
    Transform towerBase;

    private void Awake()
    {
        type = TowerTypes.UnityTower;
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
            Vector3 newDirection = Vector3.RotateTowards(towerBase.transform.forward, targetDirection, 2.0f * Time.deltaTime, 0.0f);
            towerBase.transform.rotation = Quaternion.LookRotation(newDirection);
            
        }
    }

    protected override void Fire()
    {

        if (EnemyTarget)
        {
            var newProjectile = Instantiate(projectile, spawnPoint.position, Quaternion.identity);
            turretSFX.Play();
            newProjectile.GetComponent<UnityProjectile>().SetTarget(EnemyTarget);
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
