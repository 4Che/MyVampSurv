using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveItems : MonoBehaviour
{
    [SerializeField] private List<ItemForEquip> items;

    Character character;

    [SerializeField] private ItemForEquip armorTest;

    private void Awake()
    {
        character = GetComponent<Character>();
    }

    public void Start()
    {
        Equip(armorTest);
    }

    public void Equip(ItemForEquip itemForEquipToEquip)
    {
        items ??= new List<ItemForEquip>();
        items.Add(itemForEquipToEquip);
        itemForEquipToEquip.Equip(character);
    }
    
    public void UnEquip(ItemForEquip itemForEquipToUnEquip)
    {
        
    }
}
