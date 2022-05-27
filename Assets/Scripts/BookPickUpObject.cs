using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPickUpObject : MonoBehaviour, IPickUpObject
{

    [SerializeField] private int amount;
    public void OnPickUp(Character character)
    {
        character.level.AddExperience(amount);
    }
}
