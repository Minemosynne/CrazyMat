using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Attack", fileName = "Attack")]
public class Attack : Enhancement
{
    [Header("Properties")]
    public bool basic;
    [Range(1,100)]
    public int MinDamage;
    [Range(1,100)]
    public int MaxDamage;

}
