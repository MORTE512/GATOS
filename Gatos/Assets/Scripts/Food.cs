using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Food : MonoBehaviour, I_Interact
{
    [SerializeField] private float _hungerToReplenish;
   
    public Rigidbody rb { private set; get; }

    private void Awake()
    {
        GetComponent<BoxCollider>().isTrigger = true;
        rb = GetComponent<Rigidbody>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Cat")) return;
        var Vida_gatos = other.gameObject.GetComponent<Vida_gatos>();
        if (Vida_gatos is null) return;
        if (!Vida_gatos._shouldEat) return;

        Vida_gatos.ReplenishHunger(_hungerToReplenish);
        Destroy(gameObject);
    }

    public void Interact()
    {
        var player = Movement.instance;

        //Si la distancia es mayor que "_distance" entrará en  el if;
        if (Vector3.Distance(player.transform.position, transform.position) > player.Distance)
        {
            return;
        }

        RecogerComida.instance.PickUp(this);
    }
}
