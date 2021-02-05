using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Health States, 
Default: Normal Regen rate, whatever HealthRegenRate is set too.
Regen: Increased Regen, Double HealthRegenRate.
Poison: No Regen, Decreases Health by HealthRegenRate every Round.
Paralyzed: No Regen, Nothing is Gained or Lost while Paralyzed each round. 
*/

public enum StatusEffects
{
    DEFAULT,
    REGEN,
    POISON,
    PARALYZED
};

public class HealthSystem : MonoBehaviour
{
    // Variables for the Health System

    [SerializeField]
    // Max Lives/Health the player can have
    private int MaxHealth;

    [SerializeField]
    // Total Lives/Health the player currently has
    private int Health;

    [SerializeField]
    // Lives/Health Regened per Round or Level or whenever or however long
    private int HealthRegenRate;

    [SerializeField]
    private TMPro.TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the health stays loaded inbetween levels, for saving purposes or 
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update health to any value
    public void updateHealth(int newHealth)
    {
        Health = newHealth;
    }

    // Increase Health by a set value
    public void increaseHealth(int healthAmount)
    {
        Health += healthAmount;
    }

    // Decrease Health by a set value
    public void decreaseHealth(int healthAmount)
    {
        Health -= healthAmount;
    }

    // Update  MaxHealth to any value
    public void updateMaxHealth(int newMaxHealth)
    {
        MaxHealth = newMaxHealth;
    }

    // Increase MaxHealth by a set value
    public void increaseMaxHealth(int maxHealthAmount)
    {
        MaxHealth += maxHealthAmount;
    }

    // Decrease MaxHealth by a set value
    public void decreaseMaxHealth(int maxHealthAmount)
    {
        MaxHealth -= maxHealthAmount;
    }
}
