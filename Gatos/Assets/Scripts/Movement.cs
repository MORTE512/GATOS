using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Movement : MonoBehaviour, I_Interact
{
    public static Movement instance;

    [SerializeField]
    private Camera camera;

    [SerializeField] private float _distance;
    public float Distance => _distance;

    [SerializeField] private UnityEvent _onClickSpecific;
    public UnityEvent OnClickSpecific => _onClickSpecific;

    private string groundTag = "Ground";

    public bool _shouldEat { private set; get; }



    private NavMeshAgent agent;

    private RaycastHit hit;

    private Transform _objectSelected;
    private RecogerComida _recogerComida;
    private GameObject _target;

    private void Awake()
    {
        if(instance == null) instance = this;
    }

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _recogerComida = GetComponent<RecogerComida>();
        //Nos suscribimos al Evento "OnClickOutside" del player.
        //(Esto nos sirve para que cuando se llame a este evento, el m�todo que agreguemos
        //en el AddListener se ejecute)
        Movement.instance.OnClickSpecific.AddListener(DisableShouldEat);
    }

    
    void Update()
    {
        CheckObjectDistance();
        if (_target != null)
        {
            agent.SetDestination(_target.transform.position);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (LevelManager.Instance.SalesModeActivated)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.TryGetComponent(out Vida_gatos possibleCatToSell))
                    {
                        if (possibleCatToSell.IsReadyToSell())
                        {
                            LevelManager.Instance.SellCat(possibleCatToSell);
                        }
                    }
                    else
                    {
                        LevelManager.Instance.DisableCatsReadyToSell();
                    }
                }
            }
            
            RecogerComida.instance.Throw();
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out I_Interact objectInteractable))
                {
                    _objectSelected = hit.transform;
                    _target = hit.collider.gameObject;
                    agent.SetDestination(_target.transform.position);
                    agent.isStopped = false;
                }
                else if (hit.collider.CompareTag(groundTag))
                {
                    if (UIManager.Instance.IsClientDialogPanelActive())
                    {
                        UIManager.Instance.HideClientDialog();
                    }
                    
                    _target = null;
                    agent.SetDestination(hit.point);
                    agent.isStopped = false;
                    _objectSelected = null;
                }
            }
        }
    }

    /// <summary>
    /// M�todo para comprobar la distancia entre el objeto clickado y el player;
    /// </summary>
    private void CheckObjectDistance()
    {
        //Si no tenemos objeto seleccionado no se har� la l�gica despu�s de este if;
        if (_objectSelected == null) 
        { 
            return;
        }

        //Si la distancia es menor que "_distance" entrar� en  el if;
        if (Vector3.Distance(transform.position, _objectSelected.position) <= _distance)
        {
            _objectSelected.GetComponent<I_Interact>().Interact();
            agent.isStopped = true;
            _objectSelected = null;
            _target = null;
        }
    }

    public void Interact()
    {
        _shouldEat = true;
    }

    private void DisableShouldEat()
    {
        _shouldEat = false;
    }

}
