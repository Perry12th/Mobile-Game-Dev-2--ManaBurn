using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : EnemyBase
{
    //protected void OnTriggerEnter(Collider other)
    //{
    //    ProjectileBase projectile = other.GetComponent<ProjectileBase>();

    //    if (projectile)
    //    {
    //        Destroy(other);
    //        Debug.Log("Projectile hit");
    //        OnHit(projectile); 
    //    }
    //}

    public override void OnHit(ProjectileBase projectile)
    {
        OnDeath();
    }
    protected override void OnDeath()
    {
        Debug.Log("Death");
        enemyList.Remove(this);
        Destroy(gameObject);
    }
}
