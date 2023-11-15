using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float tiempoInicial = 60f; // Tiempo inicial en segundos
    public TMP_Text contadorText; // TextMeshPro en la UI que mostrará el contador
    public GameObject panelLose; // Panel que se activará al llegar a cero

    private float tiempoRestante;
    private bool seReprodujoSonido = false;
    private bool juegoPausado = false;
    public GameObject panelOpciones;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarUI();
    }

    private void Update()
    {
        if (!juegoPausado)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime;
                if (tiempoRestante <= 0)
                {
                    tiempoRestante = 0;
                    panelLose.SetActive(true); // Activa el panel cuando el contador llega a cero
                    seReprodujoSonido = true; // Ajusta el flag para que no se reproduzca el sonido repetidamente
                }
                ActualizarUI();
            }
        }

        // Pausar o reanudar el juego al pulsar Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ReanudarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void ActualizarUI()
    {
        int segundos = Mathf.CeilToInt(tiempoRestante);
        contadorText.text = "Tiempo restante: " + segundos + "s";
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        panelOpciones.SetActive(true);
        // Detiene el tiempo del juego
        // Aquí puedes activar el panel de pausa si lo tienes
    }

    void ReanudarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        panelOpciones.SetActive(false);
        // Reanuda el tiempo del juego
        // Aquí puedes desactivar el panel de pausa si lo tienes
    }
}
