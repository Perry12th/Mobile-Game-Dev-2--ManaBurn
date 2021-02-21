using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSystem : MonoBehaviour
{
    public Item[] randomItemsToSpawn;
    public float spawnIntervals;
    public GameObject randomSpawnItem;
    public GameObject spawnedItemObject;

    //
    public float NorthBounds;
    public float SouthBounds;
    public float EastBounds;
    public float WestBounds;

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
            spawnedItemObject.transform.position = new Vector3(Random.Range(WestBounds, EastBounds), 1.0f, Random.Range(SouthBounds, NorthBounds));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Top Line
        Gizmos.DrawLine(new Vector3(WestBounds, 1.0f, NorthBounds), new Vector3(EastBounds, 1.0f, NorthBounds));
        // Left Line
        Gizmos.DrawLine(new Vector3(WestBounds, 1.0f, NorthBounds), new Vector3(WestBounds, 1.0f, SouthBounds));
        // Bot Line
        Gizmos.DrawLine(new Vector3(WestBounds, 1.0f, SouthBounds), new Vector3(EastBounds, 1.0f, SouthBounds));
        // Right Line
        Gizmos.DrawLine(new Vector3(EastBounds, 1.0f, NorthBounds), new Vector3(EastBounds, 1.0f, SouthBounds));
    }
}
