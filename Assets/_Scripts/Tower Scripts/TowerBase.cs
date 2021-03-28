using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerTypes
{ 
    UnityTower,
    UnityMk2,
    UnityMk3
}

public abstract class TowerBase : MonoBehaviour
{

    [Header("Basic Tower Stats")]
    [SerializeField]
    protected Resource resourceUsed;
    [SerializeField]
    protected int costToDeploy;
    [SerializeField]
    protected TowerTypes type;
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

    [SerializeField]
    protected bool placeable = false;

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

    public bool isPlaceable()
    {
        return placeable;
    }

    protected abstract void Fire();

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MapBounds") || (other.CompareTag("Tower") && other.gameObject != this))
            placeable = false;
        else
            placeable = true;
        //Debug.Log("Enter: " + isPlaceable());
    }

    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MapBounds") || (other.CompareTag("Tower") && other.gameObject != this))
            placeable = true;
        else
            placeable = false;
        Debug.Log("Exit: " + isPlaceable());
    }
    protected EnemyBase GetClosestEnemy()
    {
       return EnemyBase.GetClosestEnemy(transform.position, towerRange);
    }

    public virtual TowerSave Save()
    {
        TowerSave save = new TowerSave();
        save.towerID = SaveManager.instance.saveDatabase.GetTowerID[type];
        save.towerPosition = new float[] { transform.position.x, transform.position.y, transform.position.z };
        save.towerRotation = new float[] { transform.rotation.x, transform.rotation.y, transform.rotation.z };
        return save;
    }

    public virtual void Load(TowerSave save)
    {
        Vector3 newPosition = new Vector3(save.towerPosition[0], save.towerPosition[1], save.towerPosition[2]);
        Vector3 newRotation = new Vector3(save.towerRotation[0], save.towerRotation[1], save.towerRotation[2]);
        transform.position = newPosition;
        transform.eulerAngles = newRotation;
    }
}
