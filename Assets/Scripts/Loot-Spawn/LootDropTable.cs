using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/Loot drop table", fileName = "LootDropTable")]
public class LootDropTable : ScriptableObject{
    // Liste de tous les objets dropables
    public List<LootDropItem> LootDropItems;
    // Poids total de tous les objets
    private float TotalProbabilityWeight;

    // Assigne ranges aux objets
    public void LoadTable()
    {
        if(LootDropItems != null && LootDropItems.Count > 0)
        {
            float currentMaxProbabilityWeight = 0f;

            foreach (LootDropItem lootDropItem in LootDropItems)
            {
                lootDropItem.ProbabilityRangeFrom = currentMaxProbabilityWeight;
                currentMaxProbabilityWeight += lootDropItem.ProbabilityWeight;
                lootDropItem.ProbabilityRangeTo = currentMaxProbabilityWeight;
            }

            TotalProbabilityWeight = currentMaxProbabilityWeight;
        }
    }

    // Choisit l'objet qui va être droppé
    public LootDropItem PickDroppedItem()
    {
        float pickedNumber = Random.Range(0f, TotalProbabilityWeight);
        // Trouve l'objet dont la range contient le nb
        foreach(LootDropItem lootDropItem in LootDropItems)
        {
            if(pickedNumber > lootDropItem.ProbabilityRangeFrom && pickedNumber <= lootDropItem.ProbabilityRangeTo)
            {
                return lootDropItem;
            }
        }
        // Si prob, renvoie le 1er de la liste
        return LootDropItems[0];

    }
}
