using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhancement : ScriptableObject {
    public string Name = "New Enhancement";
    [Multiline(3)]
    public string Description = "Enhancement Description";

    public enum Type
    {
        ATCK,
        WPEN
    }

    public Type type;

    public bool unlocked = false;

    [Header("Recipy")]
    public int nbScrapsNeeded;
    public int nbGearsNeeded;
    public int nbMetalsNeeded;
}
