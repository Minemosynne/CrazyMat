using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Hero : MonoBehaviour {

    public string HeroName;
    public int BaseHP;
    public int CurrentHP;

    public Weapon Weapon;
    [SerializeField]
    private Inventory _playerInventory;

    private void OnEnable()
    {
        CurrentHP = BaseHP;
    }

    public int Attack(Attack attack)
    {
        Debug.Log("--->Hero attacks");
        //TODO weight & velocity influence damage
        return Random.Range(attack.MinDamage, attack.MaxDamage);
    }

    public int TakeDamage(int damage)
    {
        Debug.Log("damage received : " + damage);
        CurrentHP -= damage;
        Debug.Log("hero hp : " + CurrentHP);
        if (CurrentHP <= 0)
        {
            Die();
            return -1;
        }
        return 0;
    }

    public void Die()
    {
        Debug.Log("Enemy dead");
        //ouvre scène village; là script village spawn heros à spawnPosition & currentHp = baseHp;

    }

    public void PickUpObject()
    {
        //TODO
    }

    public void RegenerateLife()
    {

        CurrentHP += (int)Mathf.Ceil(CurrentHP * Weapon.lifeRegeneration);
        Debug.Log("-------regen life : " + CurrentHP);
    }

    public void UsePotion()
    {
        _playerInventory.nbPotions--;
        CurrentHP += (int)Mathf.Ceil(BaseHP * 0.1f);
    }
}
