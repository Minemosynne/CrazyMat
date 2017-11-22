using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public Attack baseAttack;

    public float velocity;
    public float weight;
    public float lifeRegeneration;

    public List<Attack> Attacks = new List<Attack>();
}
