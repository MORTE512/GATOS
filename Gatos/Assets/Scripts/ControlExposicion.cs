using UnityEngine;
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

        // Cargar el valor inicial del slider desde PlayerPrefs
        sliderExposicion.value = PlayerPrefs.GetFloat("Exposicion", colorAdjustments.postExposure.value);

        // Suscribirse al evento de cambio de valor del slider
        sliderExposicion.onValueChanged.AddListener(CambiarExposicion);
    }

    public void CambiarExposicion(float valor)
    {
        // Actualiza el valor de exposición en el componente ColorAdjustments
        colorAdjustments.postExposure.Override(valor);

        // Guardar el valor en PlayerPrefs
        PlayerPrefs.SetFloat("Exposicion", valor);
        PlayerPrefs.Save();
    }
}
