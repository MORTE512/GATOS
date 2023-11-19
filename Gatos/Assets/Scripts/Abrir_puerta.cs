using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrir_puerta : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Client"))
        {
            Debug.Log("hola");
            Puerta.Instance._animator_puerta.SetTrigger("Abrir_puerta");
        }
        
    }


}
