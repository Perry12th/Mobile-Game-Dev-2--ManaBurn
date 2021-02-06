using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugs : EnemyBase
{
    private void OnCollisionEnter(Collision collision)
    {
        ProjectileBase projectile = collision.gameObject.GetComponent<ProjectileBase>();
        
        if (projectile)
        {
            OnHit(projectile);
        }
        
    }
}
