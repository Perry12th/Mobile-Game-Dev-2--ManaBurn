using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityAPProjectile : ProjectileBase
{
    Vector3 moveDir;
    [SerializeField]
    float blastRange;

    // Update is called once per frame
    void Update()
    {
        transform.position += moveDir * speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        moveDir = direction;
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
