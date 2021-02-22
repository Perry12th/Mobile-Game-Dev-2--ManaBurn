using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct commands
{
    public int WaveNumber;
}

[System.Serializable]
public class EnemyManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy2;
    public int maxEnemies;

    private Queue<GameObject> enemyPool;

    public commands cmds;

    // Start is called before the first frame update
    void Start()
    {
        cmds.WaveNumber = 2;
        BuildEnemyPool(cmds);
    }

    private void BuildEnemyPool(commands cmdList)
    {
        enemyPool = new Queue<GameObject>();

        for(int i = 0; i < 10; i++)
        {
            var tempEnemy = Instantiate(enemy);
            tempEnemy.SetActive(false);
            tempEnemy.transform.parent = transform;
            enemyPool.Enqueue(tempEnemy);
        }


    }

    public GameObject GetEnemy()
    {
        var newEnemy = enemyPool.Dequeue();
        newEnemy.SetActive(true);
        return newEnemy;
    }

    public void ReturnEnemy(GameObject returnedEnemy)
    {
        returnedEnemy.SetActive(false);
        enemyPool.Enqueue(returnedEnemy);
    }
}
