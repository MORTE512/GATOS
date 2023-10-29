using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    public TMP_Text contadorText; // TextMeshPro en la UI que mostrará el contador
    public GameObject panelLose; // Panel que se activará al llegar a cero
   // public AudioClip sonidoContador; // Sonido que se reproducirá al llegar a cero
   // public AudioSource fuenteDeAudio; // Componente AudioSource para reproducir el sonido

    private float tiempoRestante;
    private bool seReprodujoSonido = false;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarUI();
    }

    private void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
            if (tiempoRestante <= 0)
            {
                tiempoRestante = 0;
                panelLose.SetActive(true); // Activa el panel cuando el contador llega a cero

                //  if (!seReprodujoSonido)
                //  {
                // ReproducirSonido();
                //  seReprodujoSonido = true;
                // }
            }
            ActualizarUI();
        }
    }

    void ActualizarUI()
    {
        int segundos = Mathf.CeilToInt(tiempoRestante);
        contadorText.text = "Tiempo restante: " + segundos + "s";
    }

    //void ReproducirSonido()
    // {
    //     if (fuenteDeAudio != null && sonidoContador != null)
    //      {
    //  fuenteDeAudio.PlayOneShot(sonidoContador);
    // }
    // }
}
