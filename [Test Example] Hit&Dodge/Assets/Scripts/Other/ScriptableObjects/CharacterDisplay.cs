using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] protected EnemyDataConfig enemyDataConfig;
    public int _healthAttributte { get; private set; }
    public int _speedAttributte { get; private set; }
    private void OnEnable()
    {
        _healthAttributte = enemyDataConfig.HealthPoint;
        _speedAttributte = enemyDataConfig.SpeedPoint;
    }
}
