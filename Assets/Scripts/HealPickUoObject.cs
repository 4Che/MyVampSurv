using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPickUoObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] private int healAmount;

    public void OnPickUp(Character character)
    {
        character.Heal(healAmount);
    }
}
