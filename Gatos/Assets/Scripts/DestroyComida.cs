using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyComida : MonoBehaviour
{
    private bool _isOnGround = false;
    private float _timeOnGround = 0f;
    private const float _timeThreshold = 3f; // Tiempo límite en el suelo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground") && gameObject.CompareTag("comida"))
        {
            _isOnGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground") && gameObject.CompareTag("comida"))
        {
            _isOnGround = false;
            _timeOnGround = 0f; // Reiniciar el tiempo si ya no está en contacto con el suelo
        }
    }
    private void Update()
    {
        if (_isOnGround)
        {
            _timeOnGround += Time.deltaTime; // Contar el tiempo en el suelo
            if (_timeOnGround > _timeThreshold)
            {
                Destroy(gameObject); // Destruir el objeto si ha estado en el suelo durante más de 3 segundos
            }
        }
    }
}
