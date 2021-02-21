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
        spawningEnemies = true;
        //This is hard coded for now lol
        for(int i = 0; i < 5; i++)
        {
            //if (Time.frameCount % Random.Range(200, 700) == 0)
           //{
                enemyManager.GetEnemy();
           // }
        }



    }

}
