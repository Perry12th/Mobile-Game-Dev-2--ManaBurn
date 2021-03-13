using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : EnemyBase
{

    public EnemyManager enemyManager;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }

    public override void OnHit(ProjectileBase projectile)
    {
        enemySFX.Play();
        health -= projectile.Damage;
        if (health <= 0)
        {
            OnDeath();
        }
       
    }
    protected override void OnDeath()
    {
        Debug.Log("Death");
        OnDestroy();
    }
}
