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
        if (itemInSlot != null)
        {
            if (itemInSlot.getUses() > 0)
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
        else
        {
            itemGameObject.SetActive(false);
            itemUsesGameObject.SetActive(false);
        }
    }

    public void useItemInSlot()
    {
        itemInSlot.useItem();
        if (itemInSlot.getUses() <= 0)
        {
            itemGameObject.SetActive(false);
            itemUsesGameObject.SetActive(false);
        }
        else
        {
            updateItem();
        }
    }

    public void updateItem()
    {
        itemUsesGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = itemInSlot.getUsesToString();
    }
}
