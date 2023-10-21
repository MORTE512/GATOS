using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Vida_gatos : MonoBehaviour, I_Interact
{
    [Header("Hunger")]
    [SerializeField] private float _maxHunger = 100f;
    [SerializeField] private float _hugerDepletionRate = 1f;
    private float _currentHunger;
    private float HungerPercent => _currentHunger / _maxHunger;

    public bool _shouldEat {private set; get;}

    public static UnityAction OnCatDied;

    private void Start()
    {
        Movement.instance.OnClickOutside.AddListener(DisableShouldEat);

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

    public void Interact()
    {
        _shouldEat = true;
    }

    private void DisableShouldEat()
    {
        _shouldEat = false;
    }
}
