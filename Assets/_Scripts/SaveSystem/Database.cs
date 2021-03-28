using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DataBase", menuName = "Save System/Database")]
public class Database : ScriptableObject
{
    [Header("Items")]
    public Item[] Items;
    public Dictionary<Item, int> GetItemID = new Dictionary<Item, int>();
    public Dictionary<int, Item> GetItem = new Dictionary<int, Item>();

    [Header("Towers")]
    public TowerTypes[] Towers;
    public GameObject[] TowerObjects;
    public Dictionary<TowerTypes, int> GetTowerID = new Dictionary<TowerTypes, int>();
    public Dictionary<int, GameObject> GetTower = new Dictionary<int, GameObject>();

    public void OnEnable()
    {
        GetItemID = new Dictionary<Item, int>();
        GetItem = new Dictionary<int, Item>();
        for (int i = 0; i <Items.Length; i++)
        {
            GetItemID.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }

        GetTowerID = new Dictionary<TowerTypes, int>();
        GetTower = new Dictionary<int, GameObject>();
        for (int i = 0; i < Towers.Length; i++)
        {
            GetTowerID.Add(Towers[i], i);
            GetTower.Add(i, TowerObjects[i]);
        }
    }
}
