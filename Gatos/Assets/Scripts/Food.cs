using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Food : MonoBehaviour
{
    [SerializeField] private float _hungerToReplenish;
    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Cat")) return;
        var Vida_gatos = other.gameObject.GetComponent<Vida_gatos>();
        if (Vida_gatos is null) return;

        Vida_gatos.ReplenishHunger(_hungerToReplenish);
        Destroy(gameObject);
    }
}
