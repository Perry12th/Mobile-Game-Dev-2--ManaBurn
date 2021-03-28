using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventroySave
{
    public List<SlotSave> slotSaves;
}

[System.Serializable]
public class SlotSave 
{
    public int itemID;
    public int numUses;
}

