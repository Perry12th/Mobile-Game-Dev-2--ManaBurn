using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Basic Enemy Stats")]
    [SerializeField]
    int health;
    [SerializeField]
    float speed;

    protected virtual void OnDeath()
    {
        Destroy(gameObject);
    }

    protected virtual void OnHit(ProjectileBase projectile)
    {
        OnDeath();
    }
    
}
