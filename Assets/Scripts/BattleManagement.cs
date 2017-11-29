using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagement : MonoBehaviour {

    public Enemy EnemyInBattle;
    public Hero HeroInBattle;
    public List<Attack> Attacks;

    public GameObject AttackPanel;
    public Transform Spacer;
    public GameObject ActionButton;

    // Use this for initialization
    void Start () {
        //Récupère Enemy
        EnemyInBattle = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        //Récupère Heros
        HeroInBattle = GameObject.Find("Hero").GetComponent<Hero>();
        //Récupère la liste d'attaques
        Attacks = HeroInBattle.GetComponent<Weapon>().Attacks;
        //Crée les boutons d'attaque
        CreateAttackButtons(HeroInBattle.GetComponent<Weapon>().baseAttack);
        foreach(Attack a in Attacks)
        {
            CreateAttackButtons(a);
        }
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

    private void CreateAttackButtons(Attack attack)
    {
        //TODO
        GameObject AttackButton = Instantiate(ActionButton) as GameObject;
        Text AttackButtonText = AttackButton.transform.Find("Text").gameObject.GetComponent<Text>();
        AttackButtonText.text = attack.Name;
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Battle(attack));
        AttackButton.transform.SetParent(Spacer, false);
    }
}
