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

    public float velocity;
    public float weight;
    public float lifeRegeneration;

    public List<Attack> Attacks = new List<Attack>();

    public void AddAttack(Attack attack)
    {
        Attacks.Add(attack);
    }

    public void EnhanceBaseAttack(Attack attack)
    {
        baseAttack = attack;
    }

    //public void EnhanceSpecifications() { }
}
