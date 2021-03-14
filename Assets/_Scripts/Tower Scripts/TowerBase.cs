using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{

    [Header("Basic Tower Stats")]
    [SerializeField]
    protected Resource resourceUsed;
    [SerializeField]
    protected int costToDeploy;

    public int cost => costToDeploy;

    [SerializeField]
    protected Sprite towerSprite;
    [SerializeField]
    protected float rateOfFire;
    [SerializeField]
    protected float towerRange;
    [SerializeField]
    protected GameObject projectile;
    [SerializeField]
    protected Transform spawnPoint;
    [SerializeField]
    protected LayerMask enemyLayers;
    [SerializeField]
    protected EnemyBase EnemyTarget;
    [SerializeField]
    protected AudioSource turretSFX;

    public Resource getResourceUsed()
    {
        return resourceUsed;
    }
    public int getResourceCost()
    {
        return costToDeploy;
    }

    public Sprite getSprite()
    {
        return GameManager.Instance.getSprite(resourceUsed);
    }
    public Sprite getTowerSprite()
    {
        return towerSprite;
    }
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
