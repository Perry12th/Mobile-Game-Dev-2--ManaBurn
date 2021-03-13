using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSystem : MonoBehaviour
{
    public Item[] randomItemsToSpawn;
    public float spawnIntervals;
    public GameObject randomSpawnItem;
    public GameObject spawnedItemObject;

    public Coroutine spawnRandomItemCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        spawnRandomItemCoroutine = StartCoroutine(spawnItems());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnItems()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnIntervals);

            spawnedItemObject = Instantiate(randomSpawnItem);
            int randItemNum = Random.Range(0, randomItemsToSpawn.Length);
            spawnedItemObject.GetComponent<RandomItemScript>().randomizedItem = randomItemsToSpawn[randItemNum];
            spawnedItemObject.transform.position = new Vector3(Random.Range(GameManager.Instance.getGameBounds().WestBounds, 
                                                                            GameManager.Instance.getGameBounds().EastBounds), 
                                                                            1.0f, 
                                                               Random.Range(GameManager.Instance.getGameBounds().SouthBounds, 
                                                                            GameManager.Instance.getGameBounds().NorthBounds));
        }
    }
}
