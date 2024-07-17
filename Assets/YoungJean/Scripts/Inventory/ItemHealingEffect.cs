using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemEft/Consumable/Health")] //ItemeEft 폴더 위치? : Inventory/ItemEft/Consumable/Health
public class ItemHealingEffect : ItemEffect
{
    public int healingPoint = 0;

    public override bool ExecuteEffect()
    {
        Debug.Log("Healing the player for " + healingPoint + " points.");
        return true;
    }
}
