using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public Item itemInSlot;
    public GameObject itemGameObject;
    public GameObject itemUsesGameObject;

    private void Awake()
    {
        if (hasItemInSlot())
        {
            itemGameObject.GetComponent<Image>().sprite = itemInSlot.getSprite();
            itemUsesGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = itemInSlot.getUsesToString();
        }
        else
        {
            itemGameObject.SetActive(false);
            itemUsesGameObject.SetActive(false);
        }
    }

    public void useItemInSlot()
    {
        if (itemInSlot.getUses() > 0)
        {
            itemInSlot.useItem();
            updateItem();
        }
    }

    public void addItemToSlot(Item item)
    {
        itemInSlot = item;

        itemGameObject.SetActive(true);
        itemUsesGameObject.SetActive(true);

        itemGameObject.GetComponent<Image>().sprite = itemInSlot.getSprite();
        itemUsesGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = itemInSlot.getUsesToString();
    }

    public void updateItem()
    {
        itemUsesGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = itemInSlot.getUsesToString();
    }

    public bool hasItemInSlot()
    {
        return itemInSlot != null;
    }

    public Item getItem()
    {
        return itemInSlot;
    }
}
