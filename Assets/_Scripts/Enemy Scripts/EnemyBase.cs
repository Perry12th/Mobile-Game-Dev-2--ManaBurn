using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public static List<EnemyBase> enemyList = new List<EnemyBase>();

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
    int health;
    [SerializeField]
    float speed;
    [SerializeField]
    protected AudioSource enemySFX;

    protected virtual void Awake()
    {
        enemyList.Add(this);
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

    private void OnDestroy()
    {
        enemyList.Remove(this);
    }

}
