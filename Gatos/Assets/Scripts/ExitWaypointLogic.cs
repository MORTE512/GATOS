using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWaypointLogic : MonoBehaviour
{

    ClientSpawner clientSpawner;

    private void Start()
    {
        clientSpawner = GameObject.FindObjectOfType<ClientSpawner>();   
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entras");
        if  (other.TryGetComponent(out Client client))
        {
            if (client.clientBuyCat)
            {
                clientSpawner.SubtractClient();
                Destroy(other.gameObject);
            }
        }
    }


}
