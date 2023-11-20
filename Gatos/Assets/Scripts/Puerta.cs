using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    
    [SerializeField] public Animator _animator_puerta;
    
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            Debug.Log("hola");
            _animator_puerta.SetTrigger("Abrir_puerta");
        }

    }


}
