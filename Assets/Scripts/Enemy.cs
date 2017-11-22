using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public enum Type
    {
        SMALL,
        BIG,
    }

    public string enemyName;
    public int baseHP;
    public int currentHP;
    
    public int minAttack;
    public int maxAttack;

    public Type type;

    public bool boss;

    private void OnEnable()
    {
        currentHP = baseHP;
    }

    public int Attack()
    {
        Debug.Log("Enemy attacks");
        return Random.Range(minAttack, maxAttack);
    }

    public int TakeDamage(int damage)
    {
        Debug.Log("damage received : " + damage);
        currentHP -= damage;
        Debug.Log("enemy hp : " + currentHP);
        if (currentHP <= 0)
        {
            Die();
            return -1;
        }
        return 0;
    }

    public void Die()
    {
        //TODO pool ?
        Debug.Log("Enemy dead");
        Destroy(gameObject);
    }
}
