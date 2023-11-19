using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    private static Puerta instance;
    public static Puerta Instance => instance;
    [SerializeField] public Animator _animator_puerta;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Client"))
        {
            Debug.Log("hola");
            _animator_puerta.SetTrigger("Abrir_puerta");
        }

    }


}
