using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Attack", fileName = "Attack")]
public class Attack : Enhancement
{
    //Si attaque basique -> remplace attaque de base quand débloquée
    //Sinon -> ajoutée à la liste d'attaques sup débloquées
    [Header("Properties")]
    public bool basic;
    [Range(1,100)]
    public int MinDamage;
    [Range(1,100)]
    public int MaxDamage;

}
