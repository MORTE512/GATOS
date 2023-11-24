using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection : MonoBehaviour
{
    public Transform transformCameraTarget; // La dirección a la que quieres que mire el Slider
    public Transform targetChild;
    public float offset;

    void Update()
    {
        // Obtén la rotación necesaria para que el Slider mire en la dirección fija
        transform.LookAt(transformCameraTarget);
        transform.position = new Vector3(transform.position.x, targetChild.position.y + offset, transform.position.z);

    }
}
