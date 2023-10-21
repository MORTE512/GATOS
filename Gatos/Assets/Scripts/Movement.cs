using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    public static Movement instance;

    [SerializeField]
    private Camera camera;

    [SerializeField] private float _distance;
    public float Distance => _distance;

    [SerializeField] private UnityEvent _onClickOutside;
    public UnityEvent OnClickOutside => _onClickOutside;

    private string groundTag = "Ground";

    private NavMeshAgent agent;

    private RaycastHit hit;

    private Transform _objectSelected;
    private RecogerComida _recogerComida;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _recogerComida = GetComponent<RecogerComida>();
    }

    
    void Update()
    {
        CheckObjectDistance();

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            OnClickOutside.Invoke();

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag(groundTag))
                {
                    agent.SetDestination(hit.point);
                    agent.isStopped = false;
                    _objectSelected = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out I_Interact objectInteractable))
                {
                    _objectSelected = hit.transform;
                    agent.SetDestination(hit.point);
                    agent.isStopped = false;

                    OnClickOutside.Invoke();
                    objectInteractable.Interact();
                }
                else
                {
                    _recogerComida.Throw();
                    _objectSelected = null;
                }
            }
        }
    }

    /// <summary>
    /// Método para comprobar la distancia entre el objeto clickado y el player;
    /// </summary>
    private void CheckObjectDistance()
    {
        //Si no tenemos objeto seleccionado no se hará la lógica después de este if;
        if (_objectSelected == null) 
        { 
            return;
        }

        //Si la distancia es menor que "_distance" entrará en  el if;
        if (Vector3.Distance(transform.position, _objectSelected.position) <= _distance)
        {
            _objectSelected.GetComponent<I_Interact>().Interact();
            agent.isStopped = true;
            _objectSelected = null;
        }
    }
}
