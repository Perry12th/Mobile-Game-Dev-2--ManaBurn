using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public static List<EnemyBase> enemyList = new List<EnemyBase>();
    public EnemyManager enemyManager;

    public static EnemyBase GetClosestEnemy(Vector3 position, float maxRange)

    {
        EnemyBase closest = null;
        foreach (EnemyBase enemy in enemyList)
        {
            if (enemy.gameObject.activeSelf)
            {


                if (Vector3.Distance(position, enemy.transform.position) <= maxRange)
                {
                    if (closest == null)
                    {
                        closest = enemy;
                    }
                    else
                    {
                        if (Vector3.Distance(position, enemy.transform.position) < Vector3.Distance(position, closest.transform.position))
                        {
                            closest = enemy;
                        }
                    }
                }
            }
        }

        return closest;
    }

    [Header("Basic Enemy Stats")]
    [SerializeField]
    protected int health;
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected AudioSource enemySFX;

    protected virtual void Awake()
    {
        enemyList.Add(this);
    }

    protected void OnDisable()
    {
        enemyList.Remove(this);
    }

    protected virtual void OnDeath()
    {
        enemyList.Remove(this);
        Destroy(gameObject);
    }

    public virtual void OnHit(ProjectileBase projectile)
    {
        OnDeath();
    }

    protected void OnDestroy()
    {
        enemyList.Remove(this);
    }
    public int getDamage()
    {
        return damage;
    }

}
