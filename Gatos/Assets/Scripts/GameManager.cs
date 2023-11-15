using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Método para cargar una escena por nombre
    public void CargarEscena(string nombreDeEscena)
    {
        SceneManager.LoadScene(nombreDeEscena);
    }

    // Método para salir del juego
    public void SalirDelJuego()
    {
        // Puedes personalizar esta parte según tu plataforma
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
