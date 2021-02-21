using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityProjectile : ProjectileBase
{
    
    EnemyBase trackingTarget;
    Vector3 targetPosition;
    Vector3 moveDir;

    public void SetTarget(EnemyBase target)
    {
        trackingTarget = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (trackingTarget.gameObject.activeSelf)
        {
            targetPosition = trackingTarget.transform.position;
            moveDir = (targetPosition - transform.position).normalized;
        }

        transform.position += moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBase possibleEnemy = other.GetComponent<EnemyBase>();

        if (possibleEnemy)
        {
            possibleEnemy.OnHit(this);
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MapBounds"))
        {
            Destroy(gameObject);
        }
    }
}
