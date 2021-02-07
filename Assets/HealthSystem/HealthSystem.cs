using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    [Header("Player Health Attributes")]
    [SerializeField]
    // Max Lives/Health the player can have
    private int maxHealth;

    [SerializeField]
    // Total Lives/Health the player currently has
    private int currentHealth;

    [SerializeField]
    // Lives/Health Regened per Round or Level or whenever or however long
    private int healthRegenRate;

    [SerializeField]
    private TextMeshProUGUI healthText;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the health stays loaded inbetween levels, for saving purposes or 
        //DontDestroyOnLoad(gameObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.SetText(currentHealth.ToString());
    }

    // Update health to any value
    public void updateHealth(int newHealth)
    {
        currentHealth = newHealth;
    }

    // Increase Health by a set value
    public void RegenHealth(int healthRegen)
    {
        currentHealth += healthRegen;
    }

    // Decrease Health by a set value
    public void Damage(int damage)
    {
        currentHealth -= damage;
    }

    // Update  MaxHealth to any value
    public void updateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
    }

    // Increase MaxHealth by a set value
    public void increaseMaxHealth(int maxHealthAmount)
    {
        maxHealth += maxHealthAmount;
    }

    // Decrease MaxHealth by a set value
    public void decreaseMaxHealth(int maxHealthAmount)
    {
        maxHealth -= maxHealthAmount;
    }
}
