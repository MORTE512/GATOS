using System.Collections;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Lista de clips de audio que se reproducirán
    public AudioClip[] playlist;

    // Referencia al componente AudioSource
    private AudioSource audioSource;

    // Índice actual en la lista de reproducción
    private int currentTrackIndex = 0;

    void Start()
    {
        // Obtén el componente AudioSource o agrégalo si no existe
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Asegúrate de que hay al menos una canción en la lista de reproducción
        if (playlist.Length > 0)
        {
            // Inicia la reproducción de la primera canción
            PlayTrack(currentTrackIndex);
        }
    }

    void Update()
    {
        // Si la canción actual ha terminado, pasa a la siguiente
        if (!audioSource.isPlaying)
        {
            NextTrack();
        }
    }

    // Función para reproducir una canción en el índice especificado
    void PlayTrack(int index)
    {
        // Asegúrate de que el índice esté en el rango correcto
        index = Mathf.Clamp(index, 0, playlist.Length - 1);

        // Establece el clip de audio y comienza la reproducción
        audioSource.clip = playlist[index];
        audioSource.Play();
    }

    // Función para pasar a la siguiente canción
    void NextTrack()
    {
        // Avanza al siguiente índice de la lista de reproducción
        currentTrackIndex = (currentTrackIndex + 1) % playlist.Length;

        // Reproduce la siguiente canción
        PlayTrack(currentTrackIndex);
    }
}
