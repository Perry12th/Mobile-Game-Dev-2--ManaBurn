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
        GameObject.Destroy(this);
    }

    protected virtual void OnHit(ProjectileBase projectile)
    {
        OnDeath();
    }
    
}
