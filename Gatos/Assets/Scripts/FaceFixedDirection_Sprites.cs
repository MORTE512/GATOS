using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FaceFixedDirection_client : MonoBehaviour
{
    public Transform transformCameraTarget; // La direcci�n a la que quieres que mire el Slider
    
    public float offset;
    public GameObject curacion;

    private void Start()
    {
        transformCameraTarget = GameObject.FindGameObjectWithTag("target").transform;
        curacion.SetActive(true);
    }
    void Update()
    {
        // Obt�n la rotaci�n necesaria para que el Slider mire en la direcci�n fija
        transform.LookAt(transformCameraTarget);
        
    }
   
}
