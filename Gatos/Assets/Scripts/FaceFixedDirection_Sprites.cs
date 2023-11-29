using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection_Sprites : MonoBehaviour
{
    public Transform transformCameraTarget; // La direcci�n a la que quieres que mire el Slider
    
    public float offset;
    public GameObject curacion;

    private void Start()
    {
        curacion.SetActive(false);
    }
    void Update()
    {
        // Obt�n la rotaci�n necesaria para que el Slider mire en la direcci�n fija
        transform.LookAt(transformCameraTarget);
        
    }
    public void descativar_curacion()
    {
        curacion.SetActive(false);
    }
}
