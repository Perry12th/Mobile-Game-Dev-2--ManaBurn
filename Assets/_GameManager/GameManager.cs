using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Resource
{
    DEFAULT = -1,
    MONEY,
    WOOD,
    STONE,
    COUNT
}

public struct gameBounds
{
    gameBounds(float nBounds, float sBounds, float eBounds, float wBounds)
    {
        NorthBounds = nBounds;
        SouthBounds = sBounds;
        EastBounds = eBounds;
        WestBounds = wBounds;
    }

    public float NorthBounds;
    public float SouthBounds;
    public float EastBounds;
    public float WestBounds;
}

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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            if (moneyText)
            {
                moneyText.text = getMoney().ToString();
            }
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        mapBoundry.WestBounds = WestBounds;
        mapBoundry.EastBounds = EastBounds;
        mapBoundry.NorthBounds = NorthBounds;
        mapBoundry.SouthBounds = SouthBounds;
    }

    [Header("Game Systems")]
    [SerializeField]
    private HealthSystem healthSystem;

    [SerializeField]
    private InventorySystem inventorySystem;

    [Header("Global Variables")]
    [SerializeField]
    private gameBounds mapBoundry;

    // These corespond to Resource Enum : element 0 = first enum, element 1 = second enum, etc...
    [SerializeField]
    private Sprite[] resourceSprites;

    [SerializeField]
    private float NorthBounds;
    [SerializeField]
    public float SouthBounds;
    [SerializeField]
    public float EastBounds;
    [SerializeField]
    public float WestBounds;

    [SerializeField]
    private float globalDamageMultiplier = 1.0f;

    [SerializeField]
    private int Money = 500;

    [SerializeField]
    private int Wood = 500;

    [SerializeField]
    private int Stone = 500;

    [Header("UI Elements")]
    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private TextMeshProUGUI woodText;

    [SerializeField]
    private TextMeshProUGUI stoneText;

    [SerializeField]
    private bool isFastFoward = false;

    public HealthSystem getHealthSystem()
    {
        return healthSystem;
    }

    public InventorySystem getInventorySystem()
    {
        return inventorySystem;
    }

    public void fastForward()
    {
        isFastFoward = !isFastFoward;
        if(isFastFoward)
        {
            Time.timeScale = 2.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    public int getMoney()
    {
        return Money;
    }

    public int getWood()
    {
        return Wood;
    }

    public int getStone()
    {
        return Stone;
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

    public void increaseWood(int woodAmount)
    {
        Wood += woodAmount;
        moneyText.text = Wood.ToString();
    }

    public void decreaseWood(int woodAmount)
    {
        Wood -= woodAmount;
        moneyText.text = Wood.ToString();
    }

    public void increaseStone(int stoneAmount)
    {
        Stone += stoneAmount;
        stoneText.text = Stone.ToString();
    }

    public void decreaseStone(int stoneAmount)
    {
        Stone -= stoneAmount;
        stoneText.text = Stone.ToString();
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

    public gameBounds getGameBounds()
    {
        return mapBoundry;
    }

    public Sprite getSprite(Resource resourceIndex)
    {
        return resourceSprites[(int)resourceIndex];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        // Top Line
        Gizmos.DrawLine(new Vector3(mapBoundry.WestBounds, 1.0f, mapBoundry.NorthBounds), new Vector3(mapBoundry.EastBounds, 1.0f, mapBoundry.NorthBounds));
        // Left Line
        Gizmos.DrawLine(new Vector3(mapBoundry.WestBounds, 1.0f, mapBoundry.NorthBounds), new Vector3(mapBoundry.WestBounds, 1.0f, mapBoundry.SouthBounds));
        // Bot Line
        Gizmos.DrawLine(new Vector3(mapBoundry.WestBounds, 1.0f, mapBoundry.SouthBounds), new Vector3(mapBoundry.EastBounds, 1.0f, mapBoundry.SouthBounds));
        // Right Line
        Gizmos.DrawLine(new Vector3(mapBoundry.EastBounds, 1.0f, mapBoundry.NorthBounds), new Vector3(mapBoundry.EastBounds, 1.0f, mapBoundry.SouthBounds));
    }
}