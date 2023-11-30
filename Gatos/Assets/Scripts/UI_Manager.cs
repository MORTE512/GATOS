using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering.Universal;


public class UI_Manager : MonoBehaviour
{
    //paneles
    //public GameObject MainPanel;
    //public GameObject ConfigurationPanel;
    //sonidos general y musica
    public List<AudioSource> GeneralSoundSources = new List<AudioSource>();
    public List<AudioSource> MusicSoundSources = new List<AudioSource>();
    public float generalVolume = 1f;
    public float musicVolume = 1f;
    public Slider MusicSlider;
    public Slider SourcGeneralSoundSlider;
    

    //idiomas
    private string currentLanguageCode;

    //brillo
    
   
    private AutoExposure autoExposure;

    // Variable para mantener el valor de exposici�n
    private float exposureValue;

    //sliders volumen

    private void Start()
    {
        // Obtener todas las instancias de AudioSource en tu juego
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();

        // Clasificar los AudioSource en las listas correspondientes
        foreach (AudioSource source in audioSources)
        {
            if (source.CompareTag("SonidoGeneral"))
            {
                GeneralSoundSources.Add(source);
            }
            else if (source.CompareTag("SonidoMusica"))
            {
                MusicSoundSources.Add(source);
            }
        }
       

       

        currentLanguageCode = PlayerPrefs.GetString("Language", "en");
        // Seleccionar el idioma actual
        StartCoroutine(SetLanguageInGame());

        //brillo
        // Intenta obtener la configuraci�n de Auto Exposure del volumen
      
        SetGeneralVolume();
        
        SetMusicVolume();
        PlayerPrefs.GetFloat("SourcGeneralSoundSlider", SourcGeneralSoundSlider.value);
        PlayerPrefs.GetFloat("musicValue", SourcGeneralSoundSlider.value);
        




    }

    public void SetGeneralVolume()
    {
        // Actualizar el volumen de la categor�a SonidoMaster
        generalVolume = SourcGeneralSoundSlider.value;

        // Actualizar el volumen de la categor�a SonidoMaster
        foreach (AudioSource source in GeneralSoundSources)
        {
            source.volume = generalVolume;
        }
        PlayerPrefs.SetFloat("SourcGeneralSoundSlider", SourcGeneralSoundSlider.value);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume()
    {
        // Actualizar el volumen de la categor�a SonidoVFX
        musicVolume = MusicSlider.value;

        // Actualizar el volumen de la categor�a SonidoVFX
        foreach (AudioSource source in MusicSoundSources)
        {
            source.volume = musicVolume;
        }

        PlayerPrefs.SetFloat("musicValue", MusicSlider.value);
        PlayerPrefs.Save();
    }

  

    public void SetLanguage(string newLanguageCode)
    {
        Dictionary<string, Locale> languageDic = new Dictionary<string, Locale>
        {
            {"es", LocalizationSettings.AvailableLocales.Locales[0]},
            {"ca", LocalizationSettings.AvailableLocales.Locales[1]},
            {"en", LocalizationSettings.AvailableLocales.Locales[2]},
            {"fr", LocalizationSettings.AvailableLocales.Locales[3]}
        };

        if (languageDic.ContainsKey(newLanguageCode))
        {
            LocalizationSettings.SelectedLocale = languageDic[newLanguageCode];
        }
        PlayerPrefs.SetString("Language", newLanguageCode);
    }

    IEnumerator SetLanguageInGame()
    {
        yield return new WaitForSeconds(0.5f);
        SetLanguage(currentLanguageCode);
    }

   

    


}
