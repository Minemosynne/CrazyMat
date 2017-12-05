using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enhancement/Weapon Enhancement", fileName = "WeaponEnhancement")]
public class WeaponEnhancement : Enhancement {

    [Header("Properties")]
    [Range(1, 100)]
    public int AugmentedVelocity;
    [Range(1, 100)]
    public int AugmentedWeight;
    [Range(1, 100)]
    public int DiminuedWeight;
    [Range(1, 100)]
    public int AugmentedLifeRegeneration;
}
