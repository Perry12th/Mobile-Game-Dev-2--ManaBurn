using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKillScript : MonoBehaviour
{



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.getHealthSystem().Damage(other.gameObject.GetComponent<EnemyBase>().getDamage());
            Destroy(other.gameObject);
        }
    }


}
