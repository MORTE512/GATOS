using UnityEngine;

public class ShowCanvasOnHover_client : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        // Obt�n el Canvas como hijo del objeto
        canvas = GetComponentInChildren<Canvas>();

        // Aseg�rate de que el canvas est� configurado correctamente
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
