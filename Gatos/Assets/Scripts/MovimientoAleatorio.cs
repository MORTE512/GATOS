using UnityEngine;
using UnityEngine.AI;

public class MovimientoAleatorio : MonoBehaviour
{
    public float velocidadMaxima;
    public float tiempoEspera = 5f;

    private NavMeshAgent navMeshAgent;
    private bool esperando;

    [SerializeField] private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        if (navMeshAgent == null)
        {
            Debug.LogError("El objeto no tiene un componente NavMeshAgent.");
            enabled = false; // Desactiva el script si no hay NavMeshAgent.
            return;
        }

        ObtenerNuevoDestino();
        esperando = false;
    }

    void Update()
    {
        if (esperando)
        {
            // Esperar durante un tiempo
            tiempoEspera -= Time.deltaTime;

            if (tiempoEspera <= 0f)
            {
                ObtenerNuevoDestino();
                tiempoEspera = 5f; // Reiniciar el tiempo de espera
            }
        }
        else
        {
            // Verificar si ha alcanzado el destino
            if (navMeshAgent.remainingDistance < 0.1f)
            {
                esperando = true;
               // animator.SetBool("isIdle", true);
            }
        }
    }

    void ObtenerNuevoDestino()
    {
        // Obtener un punto aleatorio dentro del NavMesh
        Vector3 randomDirection = Random.insideUnitSphere * 10f;
        //animator.SetBool("isIdle", false);// Ajusta el radio según sea necesario
        randomDirection += transform.position;

        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas);

        // Establecer el nuevo destino
        navMeshAgent.SetDestination(hit.position);
    }

    public void StopCatAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public void StartCatAgent()
    {
        navMeshAgent.isStopped = false;
    }

}
