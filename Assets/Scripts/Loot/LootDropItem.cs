using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Loot/Loot Item", fileName = "LootItem")]
public class LootDropItem : ScriptableObject {
    public enum Type
    {
        SCRAP,
        GEAR,
        METAL,
        POTION
    }

    public Type type;
    //Si une potion > 0
    [Range(0, 1)]
    public float lifeRegenration;

    public float probabilityWeight;

    //Range de l'item - item choisi si valeur entre RangeFrom & RangeTo
    [HideInInspector]
    public float probabilityRangeFrom;
    [HideInInspector]
    public float probabilityRangeTo;
}
