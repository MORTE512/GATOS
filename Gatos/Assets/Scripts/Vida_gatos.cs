using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Vida_gatos : MonoBehaviour
{

    [Header("Hunger")]
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hugerDepletionRate = 1f;
    private float _currentHunger;
    private float HungerPercent => _currentHunger / _maxHunger;

    public static UnityAction OnCatDied;

    private void Start()
    {
        _currentHunger = _maxHunger;
    }

    private void Update()
    {
        _currentHunger -= _hugerDepletionRate * Time.deltaTime;
        if (_currentHunger <= 0)
        {
            OnCatDied?.Invoke();
            _currentHunger = 0;

        }

    }
    public void ReplenishHunger(float hungerAmount)
    {
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;

    }



}
