using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection_Sprites : MonoBehaviour
{
    public Transform transformCameraTarget; // La dirección a la que quieres que mire el Slider
    
    public float offset;
    public GameObject curacion;

    private void Start()
    {
        curacion.SetActive(false);
    }
    void Update()
    {
        // Obtén la rotación necesaria para que el Slider mire en la dirección fija
        transform.LookAt(transformCameraTarget);
        
    }
    public void descativar_curacion()
    {
        curacion.SetActive(false);
    }
}
