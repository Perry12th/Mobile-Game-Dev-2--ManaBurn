using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveButton : MonoBehaviour
{


    public EnemyManager enemyManager;

    private bool spawningEnemies;
    private int enemiesSpawned;

    private void Update()
    {
        Debug.Log("This is the enemyList (Perry's thing) " + EnemyBase.enemyList.Count);

    }

    public void startNextWaveButton()
    {
        if (EnemyBase.enemyList.Count <= 0)
        {
            enemyManager.StartWave();

        }

    }

}
