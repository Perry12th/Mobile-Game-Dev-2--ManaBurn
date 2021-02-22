using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// GameManager that keeps track of global variables, and other Game Systems
public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            moneyText.text = getMoney().ToString();
        }
        else
        {
            Destroy(this);
        }
    }

    [Header("Game Systems")]
    [SerializeField]
    private HealthSystem healthSystem;

    [SerializeField]
    private InventorySystem inventorySystem;

    [Header("Global Variables")]
    [SerializeField]
    private float globalDamageMultiplier = 1.0f;

    [SerializeField]
    private int Money = 500;

    [Header("UI Elements")]
    [SerializeField]
    private TMPro.TextMeshProUGUI moneyText;

    public HealthSystem getHealthSystem()
    {
        return healthSystem;
    }

    public InventorySystem getInventorySystem()
    {
        return inventorySystem;
    }

    public int getMoney()
    {
        return Money;
    }
    
    public void increaseMoney(int moneyAmount)
    {
        Money += moneyAmount;
        moneyText.text = Money.ToString();
    }

    public void decreaseMoney(int moneyAmount)
    {
        Money -= moneyAmount;
        moneyText.text = Money.ToString();
    }

    public float getDamageMultiplier()
    {
        return globalDamageMultiplier;
    }

    public void increaseDamageMultiplier(float damageMultiplierIncrease)
    {
        globalDamageMultiplier += damageMultiplierIncrease;
    }

    public void decreaseDamageMultiplier(float damageMultiplierDecrease)
    {
        globalDamageMultiplier -= damageMultiplierDecrease;
    }

}