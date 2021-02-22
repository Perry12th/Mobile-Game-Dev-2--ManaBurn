using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    // Items being held in the Inventory
    [SerializeField]
    private ItemSlot[] inventoryItems;

    public SphereCollider mousePickupTrigger;
    private void Update()
    {
        PickupItemsCheck();
    }

    private void PickupItemsCheck()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseRayHit;

        if(Physics.Raycast(mouseRay, out mouseRayHit))
        {
            Vector3 hitPos = mouseRayHit.point;
            //hitPos.y = 1.0f;
            transform.position = hitPos;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("RandomItem"))
        {
            Debug.Log("Random Item Found");
            PickupItem(other.GetComponent<RandomItemScript>().randomizedItem);
            Destroy(other.gameObject);
        }
    }

    private void PickupItem(Item item)
    {
        
        bool hasItem = false;
        for(int i = 0;  i < inventoryItems.Length; i++)
        {
            if (inventoryItems[i].itemInSlot == item)
            {
                inventoryItems[i].itemInSlot.increaseUses(1);
                inventoryItems[i].updateItem();
                hasItem = true;
                break;
            }
            else
            {
                hasItem = false;
            }
        }

        if(!hasItem)
        {
            for (int i = 0; i < inventoryItems.Length; i++)
            {
                if (!inventoryItems[i].hasItemInSlot())
                {
                    inventoryItems[i].addItemToSlot(item);
                    inventoryItems[i].itemInSlot.increaseUses(1);
                    inventoryItems[i].updateItem();
                    break;
                }
            }
        }
    }
}
