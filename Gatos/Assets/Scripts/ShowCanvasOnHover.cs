using UnityEngine;

public class ShowCanvasOnHover : MonoBehaviour
{
    public Canvas canvas;

    void Start()
    {
        // Asegúrate de que el canvas esté configurado correctamente
        if (canvas != null)
        {
            // Desactiva el canvas al inicio
            canvas.gameObject.SetActive(false);
        }
    }

    void OnMouseOver()
    {
        // Muestra el canvas cuando el cursor pasa por encima del objeto
        if (canvas != null)
        {
            canvas.gameObject.SetActive(true);
        }
    }

    void OnMouseExit()
    {
        // Oculta el canvas cuando el cursor sale del objeto
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
