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
    public int waveDifficulty;

    private int waveNum;


    public commands cmds;

    // Start is called before the first frame update
    void Start()
    {
        cmds.WaveNumber = 2;
        waveNum = 0;
    }


    public void StartWave()
    {

        StartCoroutine(WaveCoroutine());
       

    }

    IEnumerator WaveCoroutine()
    {
        waveDifficulty = ++waveNum % 5 == 0 ? waveDifficulty++ : waveDifficulty;

        for (int i = 0; i < waveNum * 3; i++)
        {

            Instantiate(enemy);
            yield return new WaitForSeconds(0.2f);

        }

        for (int i = 0; i < waveDifficulty; i++)
        {
            Instantiate(enemy2);
            yield return new WaitForSeconds(0.7f);

        }
    }

}
