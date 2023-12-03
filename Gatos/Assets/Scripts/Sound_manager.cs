using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_manager : MonoBehaviour
{
    public static Sound_manager instance;
    [Header("musica")]
    public AudioClip[] audios;
    public AudioSource controlAudio;
    



  



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

  




    public void SeleccionAudio(int indice, float volumen)
    {
        controlAudio.PlayOneShot(audios[indice], volumen);
    }



}