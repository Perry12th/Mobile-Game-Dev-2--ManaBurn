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
        enemySFX.Play();
        OnDeath();
        
    }
    protected override void OnDeath()
    {
        Debug.Log("Death");

        enemyManager.ReturnEnemy(gameObject);
        //enemyList.Remove(this);
        //Destroy(gameObject, 0.1f);
    }
}
