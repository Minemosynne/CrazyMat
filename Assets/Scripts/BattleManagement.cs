using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManagement : MonoBehaviour {

    public Enemy EnemyInBattle;
    public Hero HeroInBattle;

    // Use this for initialization
    void Start () {
        //Récupère Enemy
        EnemyInBattle = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        //Récupère Heros
        HeroInBattle = GameObject.Find("Hero").GetComponent<Hero>();
    }

    public void Battle(Attack attack)
    {
        int damage;
        //Hero attaque
        damage = HeroInBattle.Attack(attack);
        if (EnemyInBattle.TakeDamage(damage) < 0)
        {
            EndBattle();
        }
        //Enemy attaque
        damage = EnemyInBattle.Attack();
        if (HeroInBattle.TakeDamage(damage) < 0)
        {
            EndBattle();
        }    
    }

    private void EndBattle()
    {
        Debug.Log("end battle");
        //TODO si gagnant -> retourne là où il est sur la map; si perdant -> retourne au village?
    }
}
