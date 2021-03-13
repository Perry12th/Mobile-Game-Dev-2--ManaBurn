using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveButton : MonoBehaviour
{


    public EnemyManager enemyManager;

    private bool spawningEnemies;
    private int enemiesSpawned;

    public void startNextWaveButton()
    {

           enemyManager.StartWave();
           


    }

}
