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
            return -1;
        }
        return 0;
    }

    private void PickUpObject(Item item)
    {
        Debug.Log("----------------ramassé : " + item.SpawnedItem.ItemType + "------------");
        _playerInventory.GetItem(item.SpawnedItem);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("--------------COLLISION-----------");
        if (collision.GetComponentInParent<Item>())
        {
            PickUpObject(collision.GetComponentInParent<Item>());
            Destroy(collision.gameObject);
        }
    }
}
