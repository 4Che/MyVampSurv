using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject dropItemPrefab;
    [SerializeField] [Range(0f,1f)] private float chance = 1f;

    private bool isQuitting = false;

    private void OnApplicationQuit()
    {
        isQuitting = true;
    }

    public void CheckDrop()
    {
        if (isQuitting)
        {
            return;
        }
        
        if (Random.value < chance)
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
        
    }
}
