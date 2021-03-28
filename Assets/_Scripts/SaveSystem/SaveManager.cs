using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using System;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance { get; private set; }
    public Database saveDatabase;
    private SaveFile saveFile;
    public bool loadOnStart = false;
    [SerializeField]
    string savePath;
    [SerializeField]
    string gameScene;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance != null)
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == gameScene && loadOnStart)
        {
            Load();
        }
    }
    public void SetLoadOnStart(bool load)
    {
        loadOnStart = load;
    }

    public void Save()
    {
        Debug.Log("Saving Game....");
        // Get all of the save data;
        saveFile = new SaveFile();
        saveFile.towerSaves = new List<TowerSave>();
        TowerBase[] towers = FindObjectsOfType<TowerBase>();
        
        foreach (TowerBase tower in towers)
        {
            saveFile.towerSaves.Add(tower.Save());
        }

        saveFile.inventroySave = GameManager.Instance.getInventorySystem().Save();
        saveFile.healthSave = GameManager.Instance.getHealthSystem().Save();
        saveFile.gameManagerSave = GameManager.Instance.Save();
        saveFile.waveNum = FindObjectOfType<EnemyManager>().GetWaveNum();

        string saveData = JsonUtility.ToJson(saveFile, true);
        Debug.Log(saveData);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();

        Debug.Log("Saved Game");
    }

    public void Load()
    {
        Debug.Log("Loading Game...");
        if (SaveExists())
        {
            saveFile = new SaveFile();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //saveFile = (SaveFile)bf.Deserialize(file);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), saveFile);
            file.Close();

            string saveData = JsonUtility.ToJson(saveFile, true);
            Debug.Log(saveData);

            // Delete all Towers
            TowerBase[] towers = FindObjectsOfType<TowerBase>();
            foreach (TowerBase tower in towers)
            {
                Destroy(tower.gameObject);
            }
            // Set the new towers

            if (saveFile.towerSaves != null)
            {
                foreach (TowerSave towerSave in saveFile.towerSaves)
                {
                    GameObject newTower = Instantiate(saveDatabase.GetTower[towerSave.towerID]);
                    newTower.GetComponent<TowerBase>().Load(towerSave);
                }
            }
            // Set the player health and wave num
            FindObjectOfType<EnemyManager>().SetWaveNum(saveFile.waveNum);
            GameManager.Instance.getHealthSystem().Load(saveFile.healthSave);
            // Set the inventory slots
            if (saveFile.inventroySave != null)
            { 
                GameManager.Instance.getInventorySystem().Load(saveFile.inventroySave);
            }
            // Set the game manager
            GameManager.Instance.Load(saveFile.gameManagerSave);
            Debug.Log("Loaded Game");
        }
        else
        {
            Debug.LogError("Attempted To Load a non-existing saveFile");
        }
    }

    public bool SaveExists()
    {
        return File.Exists(string.Concat(Application.persistentDataPath, savePath));
    }
}
