using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection_galletas : MonoBehaviour
{
    public Transform transformCameraTarget; // La direcci�n a la que quieres que mire el Slider
    
    public float offset;


    private void Start()
    {
       
    }
    void Update()
    {
        // Obt�n la rotaci�n necesaria para que el Slider mire en la direcci�n fija
        transform.LookAt(transformCameraTarget);
        
    }
    
}
