using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Spawn/Item Spawn table", fileName = "ItemSpawnTable")]
public class ItemSpawnTable : ScriptableObject
{
    // Liste de tous les objets dropables
    public List<GameObject> Items;
    // Poids total de tous les objets
    private float _totalProbabilityWeight;

    // Assigne ranges aux objets
    public void LoadTable()
    {
        if (Items != null && Items.Count > 0)
        {
            float currentMaxProbabilityWeight = 0f;

            foreach (GameObject Object in Items)
            {
                Item Item = Object.GetComponent<Item>();
                Item.SpawnedItem.ProbabilityRangeFrom = currentMaxProbabilityWeight;
                currentMaxProbabilityWeight += Item.SpawnedItem.ProbabilityWeight;
                Item.SpawnedItem.ProbabilityRangeTo = currentMaxProbabilityWeight;
            }

            _totalProbabilityWeight = currentMaxProbabilityWeight;
        }
    }

    // Choisit l'objet qui va être droppé
    public GameObject PickDroppedItem()
    {
        float pickedNumber = Random.Range(0f, _totalProbabilityWeight);
        //Trouve l'objet dont la range contient le nb
        foreach (GameObject Object in Items)
        {
            Item Item = Object.GetComponent<Item>();
            if (pickedNumber > Item.SpawnedItem.ProbabilityRangeFrom && pickedNumber <= Item.SpawnedItem.ProbabilityRangeTo)
            {
                return Object;
            }
        }
        // Si problème, renvoie le 1er de la liste
        return Items[0];

    }
}
