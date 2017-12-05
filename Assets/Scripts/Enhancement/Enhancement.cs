using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Generic", fileName = "Generic Enhancement")]
public class Enhancement : ScriptableObject {
    public string Name = "New Enhancement";
    [Multiline(3)]
    public string Description = "Description";

    public Recipy Recipy;
}
