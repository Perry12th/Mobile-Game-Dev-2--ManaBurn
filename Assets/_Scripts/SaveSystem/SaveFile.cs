using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveFile 
{
    public InventroySave inventroySave;
    public List<TowerSave> towerSaves;
    public HealthSave healthSave;
    public GameManagerSave gameManagerSave;
    public int waveNum;
}
