using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingDagger : MonoBehaviour
{
    [SerializeField] private float timeToAttack;
    private float timer;

    private PlayerMove _playerMove;

    [SerializeField] private GameObject knifePrefab;

    private void Awake()
    {
        _playerMove = GetComponentInParent<PlayerMove>();
    }

    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnKnife();

    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void SpawnKnife()
    {
        GameObject thrownKnife = Instantiate(knifePrefab);
        thrownKnife.transform.position = transform.position;
        thrownKnife.GetComponent<ThrowingDaggerProjectile>().SetDirection(_playerMove.lastHorizontalVector, 0f);
    }
}
