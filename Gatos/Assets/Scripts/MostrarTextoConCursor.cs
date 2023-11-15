using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class MostrarTextoConCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TMP_Text textoAMostrar;

    private void Start()
    {
        // Desactiva el texto al inicio
        textoAMostrar.gameObject.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Activa el texto cuando el cursor entra en el botón
        textoAMostrar.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Desactiva el texto cuando el cursor sale del botón
        textoAMostrar.gameObject.SetActive(false);
    }
}
