using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour {

    [SerializeField]
    private Inventory _inventoryDetails;
    private GameObject _heroInventory;

    [SerializeField]
    private GameObject _enhancementTemplate;
    [SerializeField]
    private GameObject _unlockedEnhancTemplate;

    private Transform _scrollViewAttacksContent;
    private Transform _scrollViewWeapEnhancContent;
    private Transform _scrollViewUnlockedContent;

    private Text _nbPotionsText;
    private Text _nbScrapsText;
    private Text _nbGearsText;
    private Text _nbMetalsText;
    private Text _weaponVelocityText;
    private Text _weaponWeightText;
    private Text _weaponLifeRegenText;

    private void Awake()
    {
        //Récupère l'interface de l'inventaire pour pouvoir l'ouvrir, la fermer, la remplir
        _heroInventory = transform.parent.Find("PlayerInventory").gameObject;
        //Récupère les zones de texte pour afficher les objets ramassés
        _nbPotionsText = _heroInventory.transform.Find("SidePanel/NbPotions").GetComponent<Text>();
        _nbScrapsText = _heroInventory.transform.Find("SidePanel/NbScraps").GetComponent<Text>();
        _nbGearsText = _heroInventory.transform.Find("SidePanel/NbGears").GetComponent<Text>();
        _nbMetalsText = _heroInventory.transform.Find("SidePanel/NbMetals").GetComponent<Text>();
        //Récupère les zones de texte des spécifications de l'arme
        _weaponVelocityText = _heroInventory.transform.Find("SidePanel/VelocityNb").GetComponent<Text>();
        _weaponWeightText = _heroInventory.transform.Find("SidePanel/WeightNb").GetComponent<Text>();
        _weaponLifeRegenText = _heroInventory.transform.Find("SidePanel/LifeRegenNb").GetComponent<Text>();
        //Récupère les 3 zones d'affichage des enhancements
        _scrollViewAttacksContent = _heroInventory.transform.Find("AttackScrollView/Viewport/Content");
        _scrollViewWeapEnhancContent = _heroInventory.transform.Find("WeaponEnhancScrollView/Viewport/Content");
        _scrollViewUnlockedContent = _heroInventory.transform.Find("UnlockedEnhancScrollView/Viewport/Content");
    }

    private void Start()
    {
        DisplayContent(0);
        FillInSidePanel();
        PopulateAttackEnhancements();
        PopulateWeaponEnhancements();
        PopulateUnlockedEnhancements();
    }

    private void Update()
    {
        //Si joueur appuie sur I -> ouvre inventaire; si ouvert -> ferme inventaire
        if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleWindow();
        }
        //Si joueur appuie sur u -> boit potion
        if (Input.GetKeyDown(KeyCode.U))
        {
            DrinkPotion();
        }
    }

    //Change l'état de la window
    //Si active -> inactive
    //Si inactive -> active
    public void ToggleWindow()
    {
        _heroInventory.SetActive(!_heroInventory.activeSelf);
    }

    //Pour afficher un seul Content
    //0 : AttacksContent
    //1 : WeapEnhancContent
    //2 : UnlockedContent
    public void DisplayContent(int i)
    {
        switch (i)
        {
            case 0:
                _scrollViewAttacksContent.parent.parent.gameObject.SetActive(true);
                _scrollViewWeapEnhancContent.parent.parent.gameObject.SetActive(false);
                _scrollViewUnlockedContent.parent.parent.gameObject.SetActive(false);
                break;
            case 1:
                _scrollViewAttacksContent.parent.parent.gameObject.SetActive(false);
                _scrollViewWeapEnhancContent.parent.parent.gameObject.SetActive(true);
                _scrollViewUnlockedContent.parent.parent.gameObject.SetActive(false);
                break;
            case 2:
                _scrollViewAttacksContent.parent.parent.gameObject.SetActive(false);
                _scrollViewWeapEnhancContent.parent.parent.gameObject.SetActive(false);
                _scrollViewUnlockedContent.parent.parent.gameObject.SetActive(true);
                break;
        }
    }

    //---------------------------------------------------Remplir inventaire---------------------------------------------------
    private void FillInSidePanel()
    {
        //Nombre objets
        _nbPotionsText.text = string.Format("Potions : {0}", _inventoryDetails.nbPotions);
        _nbScrapsText.text = string.Format("Scraps : {0}", _inventoryDetails.nbScraps);
        _nbGearsText.text = string.Format("Gears : {0}", _inventoryDetails.nbGears);
        _nbMetalsText.text = string.Format("Metals : {0}", _inventoryDetails.nbMetals);
        //Spécifications arme
        _weaponVelocityText.text = _inventoryDetails.Weapon.velocity + "";
        _weaponWeightText.text = _inventoryDetails.Weapon.weight + "";
        _weaponLifeRegenText.text = string.Format("{0}%", _inventoryDetails.Weapon.lifeRegeneration);
    }

    private void PopulateAttackEnhancements()
    {
        //Ajoute les attaques non débloquées dans AttacksContent
        foreach(var enhancement in _inventoryDetails.AttackEnhancements)
        {
            GameObject newEnhancement = Instantiate(_enhancementTemplate, _scrollViewAttacksContent);
            newEnhancement.transform.localScale = Vector3.one;
            //Ajoute nom & description
            newEnhancement.transform.Find("Name").GetComponent<Text>().text = enhancement.Name;
            newEnhancement.transform.Find("Description").GetComponent<Text>().text = enhancement.Description;
            //Ajoute nb objets nécessaires
            //En rouge si nb insuffisant
            AddRecipyText(newEnhancement, enhancement);
            //Active getButton si recette complète
            EnableGetButton(enhancement, newEnhancement);
        }
    }

    private void PopulateWeaponEnhancements()
    {
        //Ajoute les attaques non débloquées dans AttacksContent
        foreach (var enhancement in _inventoryDetails.WeaponEnhancements)
        {
            GameObject newEnhancement = Instantiate(_enhancementTemplate, _scrollViewWeapEnhancContent);
            newEnhancement.transform.localScale = Vector3.one;
            //Ajoute nom & description
            newEnhancement.transform.Find("Name").GetComponent<Text>().text = enhancement.Name;
            newEnhancement.transform.Find("Description").GetComponent<Text>().text = enhancement.Description;
            //Ajoute nb objets nécessaires
            //En rouge si nb insuffisant
            AddRecipyText(newEnhancement, enhancement);
            //Active getButton si recette complète
            EnableGetButton(enhancement, newEnhancement);
        }
    }

    private void PopulateUnlockedEnhancements()
    {
        //Ajoute les améliorations débloquées dans UnlockedContent
        foreach (var enhancement in _inventoryDetails.UnlockedEnhancements)
        {
            GameObject newEnhancement = Instantiate(_unlockedEnhancTemplate, _scrollViewUnlockedContent);
            newEnhancement.transform.localScale = Vector3.one;
            //Ajoute nom & description
            newEnhancement.transform.Find("Name").GetComponent<Text>().text = enhancement.Name;
            newEnhancement.transform.Find("Description").GetComponent<Text>().text = enhancement.Description;
        }
    }

    //Récupère tous les ingrédients nécessaires pour débloquer l'Enhancement
    //Affiche en rouge si le joueur n'en possède pas assez
    private void AddRecipyText(GameObject newEnhancement, Enhancement enhancement)
    {
        Text recipyText;
        recipyText = newEnhancement.transform.Find("PricePanel/NbScrapsNeeded").GetComponent<Text>();
        recipyText.text = _inventoryDetails.nbScraps + " / " + enhancement.nbScrapsNeeded;
        if (_inventoryDetails.nbScraps < enhancement.nbScrapsNeeded)
        {
            recipyText.color = Color.red;
        }
        recipyText = newEnhancement.transform.Find("PricePanel/NbGearsNeeded").GetComponent<Text>();
        recipyText.text = _inventoryDetails.nbGears + " / " + enhancement.nbGearsNeeded;
        if (_inventoryDetails.nbGears < enhancement.nbGearsNeeded)
        {
            recipyText.color = Color.red;
        }
        recipyText = newEnhancement.transform.Find("PricePanel/NbMetalsNeeded").GetComponent<Text>();
        recipyText.text = _inventoryDetails.nbMetals + " / " + enhancement.nbMetalsNeeded;
        if (_inventoryDetails.nbMetals < enhancement.nbMetalsNeeded)
        {
            recipyText.color = Color.red;
        }
    }

    //Affiche "Get" button à côté de l'Enhancement si le joueur a les ingrédients nécessaires
    private void EnableGetButton(Enhancement enhancement, GameObject newEnhancement)
    {
        if(_inventoryDetails.nbScraps >= enhancement.nbScrapsNeeded && _inventoryDetails.nbGears >= enhancement.nbGearsNeeded && _inventoryDetails.nbMetals >= enhancement.nbMetalsNeeded)
        {
            newEnhancement.transform.Find("GetButton").gameObject.SetActive(true);
            newEnhancement.transform.Find("GetButton").GetComponent<Button>().onClick.AddListener(delegate { UnlockOnClick(enhancement.type); });
        }
    }

    //---------------------------------------------------Débloquer Enhancement---------------------------------------------------
    public void UnlockOnClick(Enhancement.Type type)
    {
        if(type == Enhancement.Type.ATCK)
        {
            Attack enhancement = _inventoryDetails.AttackEnhancements.Find(x => x.Name.Equals(
            EventSystem.current.currentSelectedGameObject.transform.parent.Find("Name").GetComponent<Text>().text));
            if (CheckExistenceOfEnhancement(enhancement) < 0)
            {
                return;
            }
            //Retirer Scraps/Gears/Metals utilisés de l'inventaire du héros
            UpdateNbObjects(enhancement);
            //Déplace l'amélioration dans UnlockedEnhancement et MAJ weapon
            _inventoryDetails.UnlockAttackEnhancement(enhancement);
            //MAJ inventaire
            UpdateContents();
        }
        else
        {
            WeaponEnhancement enhancement = _inventoryDetails.WeaponEnhancements.Find(x => x.Name.Equals(
            EventSystem.current.currentSelectedGameObject.transform.parent.Find("Name").GetComponent<Text>().text));
            if (CheckExistenceOfEnhancement(enhancement) < 0)
            {
                return;
            }
            //Retirer Scraps/Gears/Metals utilisés de l'inventaire du héros
            UpdateNbObjects(enhancement);
            //Déplace l'amélioration dans UnlockedEnhancement et MAJ weapon
            _inventoryDetails.UnlockWeaponEnhancement(enhancement);
            //MAJ inventaire
            UpdateContents();
        }
    }
    
    private void ClearInventory()
    {
        //Vide UnlockedContent
        if(_scrollViewUnlockedContent == null)
        {
            _scrollViewUnlockedContent = _heroInventory.transform.Find("Scroll View/Viewport/UnlockedContent");
        }
        foreach(Transform child in _scrollViewUnlockedContent)
        {
            Destroy(child.gameObject);
        }
        //Vide AttacksContent
        if (_scrollViewAttacksContent == null)
        {
            _scrollViewAttacksContent = _heroInventory.transform.Find("Scroll View/Viewport/AttacksContent");
        }
        foreach (Transform child in _scrollViewAttacksContent)
        {
            Destroy(child.gameObject);
        }
        //Vide WeapEnhancContent
        if (_scrollViewWeapEnhancContent == null)
        {
            _scrollViewWeapEnhancContent = _heroInventory.transform.Find("Scroll View/Viewport/WeapEnhancContent");
        }
        foreach (Transform child in _scrollViewWeapEnhancContent)
        {
            Destroy(child.gameObject);
        }
    }

    //Vérifie que l'Enhancement se trouve bien dans les Data
    private int CheckExistenceOfEnhancement(Enhancement enhancement)
    {
        //Si on ne trouve pas l'amélioration ou le héros n'a pas assez pour le débloquer
        if (enhancement == null)
        {
            Debug.Log("Ne trouve pas l'amélioration parmi les data");
            return -1;
        }
        else if (_inventoryDetails.nbScraps < enhancement.nbScrapsNeeded || _inventoryDetails.nbGears < enhancement.nbGearsNeeded || _inventoryDetails.nbMetals < enhancement.nbMetalsNeeded)
        {
            Debug.Log("Enhancement ne peut pas être débloqué");
            return -1;
        }
        return 0;
    }

    //Met à jour le nombre d'items ramassés après le débloquage d'un Enhancement
    private void UpdateNbObjects(Enhancement enhancement)
    {
        //Retirer Scraps/Gears/Metals utilisés de l'inventaire du héros
        _inventoryDetails.nbScraps -= enhancement.nbScrapsNeeded;
        _inventoryDetails.nbGears -= enhancement.nbGearsNeeded;
        _inventoryDetails.nbMetals -= enhancement.nbMetalsNeeded;
    }

    //Appelé quand un Enhancement est débloqué pour vider l'affichage de l'inventaire pour ensuite mettre à jour
    private void UpdateContents()
    {
        ClearInventory();
        PopulateAttackEnhancements();
        PopulateWeaponEnhancements();
        PopulateUnlockedEnhancements();
        FillInSidePanel();
    }

    //---------------------------------------------------Récupérer loot---------------------------------------------------
    public void GetLootDropped(LootDropItem item)
    {
        _inventoryDetails.GetItem(item);
    }

    //---------------------------------------------------Boire potion---------------------------------------------------
    public void DrinkPotion()
    {
        Debug.Log("---Drink potion---");
        if (_inventoryDetails.nbPotions != 0)
        {
            _inventoryDetails.DrinkPotion();
        }
        else
        {
            //TODO afficher msg indiquant plus de potion
        }
    }
}
