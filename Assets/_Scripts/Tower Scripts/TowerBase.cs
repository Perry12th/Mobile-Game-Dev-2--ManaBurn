using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{

    [Header("Basic Tower Stats")]
    [SerializeField]
    protected int costToDeploy;
    public int cost => costToDeploy;
    [SerializeField]
    protected float rateOfFire;
    [SerializeField]
    protected float towerRange;
    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected Transform sapwnPoint;
    [SerializeField]
    protected LayerMask enemyLayers;
    [SerializeField]
    protected EnemyBase EnemyTarget;
    [SerializeField]
    protected AudioSource turretSFX;

    protected abstract void Fire();

    

    //protected virtual void OnTriggerEnter(Collider other)
    //{
    //    EnemyBase possibleEnemy = other.GetComponent<EnemyBase>();

    //    if (possibleEnemy && EnemyTarget == null)
    //    {
    //        EnemyTarget = possibleEnemy.gameObject;
    //    }
    //}

    protected EnemyBase GetClosestEnemy()
    {
       return EnemyBase.GetClosestEnemy(transform.position, towerRange);
    }

}
