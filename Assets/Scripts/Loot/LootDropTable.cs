using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/Loot drop table", fileName = "LootDropTable")]
public class LootDropTable : ScriptableObject{
    //Liste de tous les objets dropables
    public List<LootDropItem> lootDropItems;
    //Poids total de tous les objets
    private float totalProbabilityWeight;

    //Assigne ranges aux objets
    public void LoadTable()
    {
        if(lootDropItems != null && lootDropItems.Count > 0)
        {
            float currentMaxProbabilityWeight = 0f;

            foreach (LootDropItem lootDropItem in lootDropItems)
            {
                lootDropItem.probabilityRangeFrom = currentMaxProbabilityWeight;
                currentMaxProbabilityWeight += lootDropItem.probabilityWeight;
                lootDropItem.probabilityRangeTo = currentMaxProbabilityWeight;
            }

            totalProbabilityWeight = currentMaxProbabilityWeight;
        }
    }

    //Choisis l'objet qui va être droppé
    public LootDropItem PickDroppedItem()
    {
        float pickedNumber = Random.Range(0f, totalProbabilityWeight);
        //Trouve l'objet dont la range contient le nb
        foreach(LootDropItem lootDropItem in lootDropItems)
        {
            if(pickedNumber > lootDropItem.probabilityRangeFrom && pickedNumber <= lootDropItem.probabilityRangeTo)
            {
                return lootDropItem;
            }
        }
        //Si prob, renvoie le 1er de la liste
        return lootDropItems[0];

    }
}
