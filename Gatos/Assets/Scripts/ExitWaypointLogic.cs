using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWaypointLogic : MonoBehaviour
{

    ClientSpawner clientSpawner;
    bool playerEnter;

    private void Start()
    {
        clientSpawner = GameObject.FindObjectOfType<ClientSpawner>();   
    }


    private void OnTriggerEnter(Collider other)
    {

        if  (other.TryGetComponent(out Client client))
        {
            if (client.clientBuyCat && !playerEnter)
            {
                playerEnter = true;
                clientSpawner.SubtractClient();
                Destroy(other.gameObject);
                playerEnter = false;
            }
        }
    }


}
