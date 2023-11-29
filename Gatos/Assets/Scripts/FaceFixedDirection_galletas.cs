using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection_galletas : MonoBehaviour
{
    public Transform transformCameraTarget; // La dirección a la que quieres que mire el Slider
    
    public float offset;
    

    
    void Update()
    {
        // Obtén la rotación necesaria para que el Slider mire en la dirección fija
        transform.LookAt(transformCameraTarget);
        
    }
    
}
