using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Attack baseAttack;

    public enum Type
    {
        LIGHT,
        HEAVY
    }

    public Type type;

    public int velocity;
    public int weight;
    public int lifeRegeneration;

    public List<Attack> Attacks = new List<Attack>();

    public void AddAttack(Attack attack)
    {
        Attacks.Add(attack);
    }

    public void EnhanceBaseAttack(Attack attack)
    {
        baseAttack = attack;
    }

    public void EnhanceSpecifications( WeaponEnhancement enhancement)
    {
        velocity += enhancement.AugmentedVelocity;
        weight += (enhancement.AugmentedWeight - enhancement.DiminuedWeight);
        lifeRegeneration += enhancement.AugmentedLifeRegeneration;
    }
}
