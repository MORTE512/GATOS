using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection : MonoBehaviour
{
    public Transform transformCameraTarget; // La direcci�n a la que quieres que mire el Slider
    public Transform targetChild;
    public float offset;

    void Update()
    {
        // Obt�n la rotaci�n necesaria para que el Slider mire en la direcci�n fija
        transform.LookAt(transformCameraTarget);
        transform.position = new Vector3(transform.position.x, targetChild.position.y + offset, transform.position.z);

    }
}
