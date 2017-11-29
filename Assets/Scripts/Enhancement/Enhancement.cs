using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Generic", fileName = "Generic Enhancement")]
public class Enhancement : ScriptableObject {
    public string Name = "New Attack";
    [Multiline(3)]
    public string Description = "Attack Description";

    public Recipy Recipy;
}
