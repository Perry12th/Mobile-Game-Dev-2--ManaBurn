using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("Item Properties")]
    [SerializeField]
    private Sprite itemIcon;

    [SerializeField]
    private string Description;

    [SerializeField]
    private int Uses;

    [Header("Item Variables")]
    [SerializeField]
    private bool affectsHealth;

    [SerializeField]
    private bool affectsDamageMultiplier;

    [SerializeField]
    private bool givesMoney;

    [SerializeField]
    private int healthChange;

    [SerializeField]
    private float damageMultiplier;

    [SerializeField]
    private int amountOfMoney;

    public void useItem()
    {
        if (--Uses >= 0)
        {

            if (affectsHealth)
            {
                if (healthChange > 0)
                    GameManager.Instance.getHealthSystem().RegenHealth(healthChange);
                else if (healthChange < 0)
                    GameManager.Instance.getHealthSystem().Damage(-healthChange);
                else
                    GameManager.Instance.getHealthSystem().RegenHealth(5);
            }

            if (affectsDamageMultiplier)
            {
                if (damageMultiplier > 0)
                    GameManager.Instance.increaseDamageMultiplier(damageMultiplier);
                else if (damageMultiplier < 0)
                    GameManager.Instance.decreaseDamageMultiplier(-damageMultiplier);
                else
                    GameManager.Instance.increaseDamageMultiplier(1.0f);
            }

            if (givesMoney)
            {
                if (amountOfMoney > 0)
                    GameManager.Instance.increaseMoney(amountOfMoney);
                else if (amountOfMoney < 0)
                    GameManager.Instance.decreaseMoney(-amountOfMoney);
                else
                    GameManager.Instance.increaseMoney(50);
            }

        }
    }

    public Sprite getSprite()
    {
        return itemIcon;
    }

    public int getUses()
    {
        return Uses;
    }

    public string getUsesToString()
    {
        return Uses.ToString();
    }

    public void increaseUses(int num)
    {
        Uses += num;
    }

    public void setUses(int num)
    {
        Uses = num;
    }
}
