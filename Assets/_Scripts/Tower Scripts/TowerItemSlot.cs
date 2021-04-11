using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerItemSlot : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public GameObject towerPrefab;
    public GameObject towerPrefabSpawned;

    public GameObject towerGameObject;
    public GameObject towerCostGameObject;
    public GameObject towerResourceImageGameObject;

    public bool validPlacement = false;
    private void Start()
    {
        if(hasTowerInSlot())
        {
            towerGameObject.SetActive(true);
            towerCostGameObject.SetActive(true);
            towerResourceImageGameObject.SetActive(true);

            towerGameObject.GetComponent<Image>().sprite = towerPrefab.GetComponent<TowerBase>().getTowerSprite();
            towerCostGameObject.GetComponent<TMPro.TextMeshProUGUI>().text = towerPrefab.GetComponent<TowerBase>().getResourceCost().ToString();
            towerResourceImageGameObject.GetComponent<Image>().sprite = towerPrefab.GetComponent<TowerBase>().getSprite();
        }
        else
        {
            towerGameObject.SetActive(false);
            towerCostGameObject.SetActive(false);
            towerResourceImageGameObject.SetActive(false);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        towerPrefabSpawned = Instantiate(towerPrefab);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit mouseRayHit;

        if(Physics.Raycast(mouseRay, out mouseRayHit))
        {
            Vector3 towerPos = mouseRayHit.point;
            gameBounds mapBoundry = GameManager.Instance.getGameBounds();

            towerPos.y = 0.0f;
            if (towerPos.x < mapBoundry.WestBounds)
                towerPos.x = mapBoundry.WestBounds;
            else if (towerPos.x > mapBoundry.EastBounds)
                towerPos.x = mapBoundry.EastBounds;

            if (towerPos.z < mapBoundry.SouthBounds)
                towerPos.z = mapBoundry.SouthBounds;
            else if (towerPos.z > mapBoundry.NorthBounds)
                towerPos.z = mapBoundry.NorthBounds;

            towerPrefabSpawned.transform.position = towerPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        TowerBase tb = towerPrefabSpawned.GetComponent<TowerBase>();
        if (tb.isPlaceable())
        {
            GameManager gm = GameManager.Instance;
            switch (tb.getResourceUsed())
            {
                case Resource.MONEY:
                    if (gm.getMoney() < tb.getResourceCost())
                    {
                        Destroy(towerPrefabSpawned);
                        break;
                    }
                    gm.decreaseMoney(tb.getResourceCost());
                    break;

                case Resource.WOOD:
                    if (gm.getWood() < tb.getResourceCost())
                    {
                        Destroy(towerPrefabSpawned);
                        break;
                    }
                    gm.decreaseWood(tb.getResourceCost());
                    break;

                case Resource.STONE:
                    if (gm.getStone() < tb.getResourceCost())
                    {
                        Destroy(towerPrefabSpawned);
                        break;
                    }
                    gm.decreaseStone(tb.getResourceCost());
                    break;

                default:
                    if (gm.getMoney() < tb.getResourceCost())
                    {
                        Destroy(towerPrefabSpawned);
                        break;
                    }
                    gm.decreaseMoney(tb.getResourceCost());
                    break;
            }
        }
        else
        {
            Destroy(towerPrefabSpawned);
        }
    }

    public bool hasTowerInSlot()
    {
        return towerPrefab != null;
    }
}
