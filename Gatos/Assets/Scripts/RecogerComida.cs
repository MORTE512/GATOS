using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerComida : MonoBehaviour
{
    public static RecogerComida instance;

    [Tooltip("Posición donde la comida se recogerá")]
    [SerializeField] private Transform _foodPosition;

    private Food _foodGetted;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// Método para recoger la comida;
    /// </summary>
    /// <param name="food"></param>
    public void PickUp(Food food)
    {
        _foodGetted = food;
        
        _foodGetted.rb.isKinematic = true;

        _foodGetted.transform.SetParent(_foodPosition);
        _foodGetted.transform.localPosition = Vector3.zero;
    }

    /// <summary>
    /// Método para soltar la comida;
    /// </summary>
    public void Throw()
    {
        if (_foodGetted == null) 
        {
            return;
        }

        _foodGetted.transform.SetParent(null);
        _foodGetted.rb.isKinematic = false;
    }
}    
    

