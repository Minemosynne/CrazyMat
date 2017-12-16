using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Weapon Enhancement", fileName = "WeaponEnhancement")]
public class WeaponEnhancement : Enhancement
{

    [Header("Properties")]
    [Range(0,1)]
    public float AugmentedVelocity;
    [Range(0, 1)]
    public float AugmentedWeight;
    [Range(0, 1)]
    public float DiminuedWeight;
    [Range(0, 1)]
    public float AugmentedLifeRegeneration;
}
