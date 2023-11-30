using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ControlExposicion : MonoBehaviour
{
    public Slider sliderExposicion;
    public Volume postProcessingVolume;
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        // Asegúrate de que el volumen de post-procesamiento está adjunto
        if (!postProcessingVolume)
        {
            Debug.LogError("No se encontró el componente Volume de Post-Procesamiento.");
            enabled = false; // Desactiva el script
            return;
        }

        // Intenta obtener el componente ColorAdjustments del volumen
        if (!postProcessingVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.LogError("No se encontró el componente Color Adjustments en el volumen.");
            enabled = false; // Desactiva el script
            return;
        }

        sliderExposicion.value = PlayerPrefs.GetFloat("brilloValue");
        colorAdjustments.postExposure.Override(sliderExposicion.value);
        // Cargar el valor inicial del slider desde el objeto persistente

        // Suscribirse al evento de cambio de valor del slider
        sliderExposicion.onValueChanged.AddListener(CambiarExposicion);
    }

    public void CambiarExposicion(float valor)
    {
        // Actualiza el valor de exposición en el componente ColorAdjustments
        colorAdjustments.postExposure.Override(valor);

        // Actualiza el valor en el objeto persistente
        PlayerPrefs.SetFloat("brilloValue", valor);
        PlayerPrefs.Save();
    }
}
