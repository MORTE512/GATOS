using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Vida_gatos : MonoBehaviour
{
    [Header("Hunger")]
    [SerializeField] public float _maxHunger = 100f;
    [SerializeField] public float _hungerDepletionRate = 1f;
    public float _currentHunger;
    public float HungerPercent => _currentHunger / _maxHunger;
    public Slider SliderHungerCat;

    

    public bool _shouldEat {private set; get;}

    public static UnityAction OnCatDied;

    private void Start()
    {
 

        _currentHunger = _maxHunger;
    }
   

    private void Update()
    {
        SliderHungerCat.value = _currentHunger;
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;
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
