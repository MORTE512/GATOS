using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Lista de clips de audio que se reproducir�n
    public AudioClip[] playlist;

    // Referencia al componente AudioSource
    private AudioSource audioSource;

    // �ndice actual en la lista de reproducci�n
    private int currentTrackIndex = 0;

    void Start()
    {
        // Obt�n el componente AudioSource o agr�galo si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Aseg�rate de que hay al menos una canci�n en la lista de reproducci�n
        if (playlist.Length > 0)
        {
            // Inicia la reproducci�n de la primera canci�n
            PlayTrack(currentTrackIndex);
        }
    }

    void Update()
    {
        // Si la canci�n actual ha terminado, pasa a la siguiente
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    // Funci�n para reproducir una canci�n en el �ndice especificado
    void PlayTrack(int index)
    {
        // Aseg�rate de que el �ndice est� en el rango correcto
        index = Mathf.Clamp(index, 0, playlist.Length - 1);

        // Establece el clip de audio y comienza la reproducci�n
        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    // Funci�n para pasar a la siguiente canci�n
    void NextTrack()
    {
        // Avanza al siguiente �ndice de la lista de reproducci�n
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;

        // Reproduce la siguiente canci�n
        PlayTrack(currentTrackIndex);
    }
}
