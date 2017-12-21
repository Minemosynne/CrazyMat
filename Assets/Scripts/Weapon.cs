using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Weapon", fileName = "Weapon")]
public class Weapon : ScriptableObject
{

    public Attack BaseAttack;

    public enum Type
    {
        LIGHT,
        HEAVY
    }

    public Type type;

    public float velocity;
    public float weight;
    [Range(0, 1)]
    public float lifeRegeneration;

    public List<Attack> Attacks = new List<Attack>();
    public List<WeaponEnhancement> WeaponEnhancements = new List<WeaponEnhancement>();

    //Ajoute une attaque à la liste d'attaques supplémentaires débloquées
    public void AddAttack(Attack attack)
    {
        Attacks.Add(attack);
    }

    //Remplace l'attaque de base par une autre
    public void EnhanceBaseAttack(Attack attack)
    {
        BaseAttack = attack;
    }

    //Ajoute l'amélioration d'arme à la liste d'améliorations débloquées
    public void EnhanceSpecifications(WeaponEnhancement enhancement)
    {
        WeaponEnhancements.Add(enhancement);
        velocity += enhancement.AugmentedVelocity;
        weight += (enhancement.AugmentedWeight - enhancement.DiminuedWeight);
        lifeRegeneration += enhancement.AugmentedLifeRegeneration;
    }
}