using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManagement : MonoBehaviour
{

    public SceneLoader SceneLoader;

    public Enemy EnemyInBattle;
    public Hero HeroInBattle;
    public List<Attack> Attacks;

    public GameObject AttackPanel;
    public Transform Spacer;
    public GameObject ActionButton;
    [SerializeField]
    private LootDropTable _lootDropTable;
    [SerializeField]
    private Inventory _playerInventory;
    private int _nbMaxDrop;

    private GameObject _player;

    void Start()
    {
        //Pour garder le player à la même position si retourne sur la map
        _player = GameObject.FindGameObjectWithTag("Player");
        //Pour ne pas le voir à l'écran
        _player.SetActive(false);
        //Récupère Enemy et le positionne sur la scène de combat
        EnemyInBattle = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        GameObject.FindGameObjectWithTag("Enemy").transform.position = new Vector3(-5, 0, 10);
        //Récupère Hero
        HeroInBattle = GameObject.Find("Hero").GetComponent<Hero>();
        //Récupère la liste d'attaques
        Attacks = HeroInBattle.Weapon.Attacks;
        //Crée les boutons d'attaque
        CreateAttackButtons(HeroInBattle.Weapon.BaseAttack);
        foreach (Attack a in Attacks)
        {
            CreateAttackButtons(a);
        }
        //Initilise drop ranges des objets de la droptable
        _lootDropTable.LoadTable();
        SetNbMaxDrop();
    }

    //Appelée à chaque fois que le joueur clique sur une attaque
    public void Battle(Attack attack)
    {
        int damage;
        //Hero attaque
        damage = HeroInBattle.Attack(attack);
        if (EnemyInBattle.TakeDamage(damage) < 0)
        {
            EndBattle(false);
        }
        else
        {
            //Enemy attaque
            damage = EnemyInBattle.Attack();
            if (HeroInBattle.TakeDamage(damage) < 0)
            {
                EndBattle(true);
            }
            else
            {
                HeroInBattle.RegenerateLife();
            }

        }
    }

    private void EndBattle(bool lost)
    {
        if (lost)
        {
            //Respawn au village - full health
            Debug.Log("---------------END BATTLE--------------");
            SceneLoader.LoseFight();

        }
        else
        {
            //Retourne où il était sur la carte - health change pas
            Debug.Log("---------------END BATTLE--------------");
            DropItem();
            _player.SetActive(true);
            _player.GetComponent<Hero>().CurrentHP = HeroInBattle.CurrentHP;
            SceneLoader.WinFight();
        }
    }

    //Initialise les boutons d'attaque
    private void CreateAttackButtons(Attack attack)
    {
        GameObject AttackButton = Instantiate(ActionButton) as GameObject;
        Text AttackButtonText = AttackButton.transform.Find("Text").gameObject.GetComponent<Text>();
        AttackButtonText.text = attack.Name;
        AttackButton.GetComponent<Button>().onClick.AddListener(() => Battle(attack));
        AttackButton.transform.SetParent(Spacer, false);
    }

    //Initialise le nombre maximum d'items dropped en fonction du type de l'ennemi
    private void SetNbMaxDrop()
    {
        switch (EnemyInBattle.type)
        {
            case Enemy.Type.SMALL:
                _nbMaxDrop = 3;
                break;
            case Enemy.Type.BIG:
                _nbMaxDrop = 5;
                break;
            case Enemy.Type.SMALL_BOSS:
                _nbMaxDrop = 7;
                break;
            case Enemy.Type.BIG_BOSS:
                _nbMaxDrop = 10;
                break;
        }
    }

    //Choisit les différents items dropped
    private void DropItem()
    {
        int nbItemsDropped = Random.Range(1, _nbMaxDrop);
        Debug.Log("---- items dropped : " + nbItemsDropped);
        for (int i = 0; i < nbItemsDropped; i++)
        {
            LootDropItem item = _lootDropTable.PickDroppedItem();
            //TODO appeler inventoryController plutôt
            _playerInventory.GetItem(item);
            Debug.Log("---- Dropped : " + item.ItemType + " ----");
        }
    }
}