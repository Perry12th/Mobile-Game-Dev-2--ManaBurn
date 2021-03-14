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
            towerPrefabSpawned.transform.position = mouseRayHit.point;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (validPlacement)
        {

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
