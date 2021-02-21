using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAPProjectile : ProjectileBase
{
    EnemyBase trackingTarget;
    Vector3 targetPosition;
    Vector3 moveDir;

    [SerializeField]
    float blastRange;

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

    public void SetTarget(EnemyBase target)
    {
        trackingTarget = target;
    }

    private void OnTriggerEnter(Collider other)
    {
        EnemyBase possibleEnemy = other.GetComponent<EnemyBase>();

        if (possibleEnemy)
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, blastRange, enemyLayer);

            foreach(var enemy in enemies)
            {
                enemy.GetComponent<EnemyBase>().OnHit(this);
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MapBounds"))
        {
            Destroy(gameObject);
        }
    }
}
