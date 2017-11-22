using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero : MonoBehaviour {

    public string heroName;
    public int baseHP;
    public int currentHP;

    private void OnEnable()
    {
        currentHP = baseHP;
    }

    public int Attack(Attack attack)
    {
        Debug.Log("Hero attacks");
        return Random.Range(attack.minDamage, attack.maxDamage);
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

    private void ChooseAttack()
    {
        Destroy(gameObject);
    }
}
