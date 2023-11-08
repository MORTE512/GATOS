using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection : MonoBehaviour
{
    public Transform transformCameraTarget; // La direcci�n a la que quieres que mire el Slider

    void Update()
    {
        // Obt�n la rotaci�n necesaria para que el Slider mire en la direcci�n fija
        transform.LookAt(transformCameraTarget, Vector3.up);


    }
}
