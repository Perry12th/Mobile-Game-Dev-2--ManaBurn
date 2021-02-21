using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemScript : MonoBehaviour
{
    public Item randomizedItem;

    public void Start()
    {
        GetComponent<SpriteRenderer>().sprite = randomizedItem.getSprite();
        StartCoroutine(destroySelf());
    }

    private IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }
}
