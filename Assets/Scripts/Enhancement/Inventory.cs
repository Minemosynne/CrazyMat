using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Inventory", fileName = "InventoryData")]
public class Inventory : ScriptableObject
{
    public Weapon Weapon;
    [Header("Lists")]
    public List<Enhancement> UnlockedEnhancements = new List<Enhancement>();
    public List<Attack> AttackEnhancements = new List<Attack>();
    public List<WeaponEnhancement> WeaponEnhancements = new List<WeaponEnhancement>();
    [Header("Picked-up objects")]
    public int nbScraps;
    public int nbGears;
    public int nbMetals;
    public int nbPotions;

    public void UnlockAttackEnhancement(Attack enhancement)
    {
        AttackEnhancements.Remove(enhancement);
        enhancement.unlocked = true;
        UnlockedEnhancements.Add(enhancement);
        //Si attaque basique -> remplace attaque de base quand débloquée
        //Sinon -> ajoutée à la liste d'attaques sup débloquées
        if (enhancement.basic)
        {
            Weapon.EnhanceBaseAttack(enhancement);
        }
        else
        {
            Weapon.AddAttack(enhancement);
        }
    }


    public void UnlockWeaponEnhancement(WeaponEnhancement enhancement)
    {
        WeaponEnhancements.Remove(enhancement);
        enhancement.unlocked = true;
        UnlockedEnhancements.Add(enhancement);
        Weapon.EnhanceSpecifications(enhancement);
    }

    public void GetItem(LootDropItem item)
    {
        switch (item.ItemType)
        {
            case LootDropItem.Type.SCRAP:
                nbScraps++;
                break;
            case LootDropItem.Type.GEAR:
                nbGears++;
                break;
            case LootDropItem.Type.METAL:
                nbMetals++;
                break;
            case LootDropItem.Type.POTION:
                nbPotions++;
                break;
        }
    }

    public void DrinkPotion()
    {
        nbPotions--;
    }
}