using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyManager : MonoBehaviour
{

    public GameObject enemy;
    public GameObject enemy2;
    public int maxEnemies;

    private Queue<GameObject> enemyPool;

    // Start is called before the first frame update
    void Start()
    {
        BuildEnemyPool();
    }

    private void BuildEnemyPool()
    {
        enemyPool = new Queue<GameObject>();

        for(int i = 0; i < maxEnemies; i++)
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
