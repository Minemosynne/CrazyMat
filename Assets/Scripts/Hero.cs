using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero : MonoBehaviour {

    public string heroName;
    public int baseHP;
    public int currentHP;

    public int nbScraps;
    public int nbGears;
    public int nbMetals;

    //TODO stock de potions

    private void OnEnable()
    {
        currentHP = baseHP;
    }

    public int Attack(Attack attack)
    {
        Debug.Log("Hero attacks");
        //TODO weight & velocity influence damage
        return Random.Range(attack.MinDamage, attack.MaxDamage);
    }

    public int TakeDamage(int damage)
    {
        Debug.Log("damage received : " + damage);
        currentHP -= damage;
        Debug.Log("hero hp : " + currentHP);
        if (currentHP <= 0)
        {
            Die();
            return -1;
        }
        return 0;
    }

    public void Die()
    {
        //TODO
        Debug.Log("Enemy dead");
    }

    public void PickUpObject()
    {
        //TODO
    }

    public void RegenerateLife()
    {
        //TODO
    }
}
