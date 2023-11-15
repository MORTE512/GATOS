using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // M�todo para cargar una escena por nombre
    public void CargarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
    }

    // M�todo para salir del juego
    public void SalirDelJuego()
    {
        // Puedes personalizar esta parte seg�n tu plataforma
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
