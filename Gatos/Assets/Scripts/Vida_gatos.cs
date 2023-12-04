using UnityEngine;
using UnityEngine.UI;

public class Vida_gatos : MonoBehaviour, I_Interact
{
    private static Vida_gatos instance;
    public static Vida_gatos Instance => instance;


    [Header("Hunger")] [SerializeField] public float _maxHunger = 100f;
    [SerializeField] public float _hungerDepletionRate;
    [SerializeField] private float _currentHunger;
    public Slider SliderHungerCat;


    [Space] [Header("---- FEEDBACK MATERIALS ----")]
    private MeshRenderer _meshRenderer;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material readyToSellMaterial;
    [SerializeField] public GameObject modelNoOutline;
    [SerializeField] public GameObject modelOutline_shell;
    [SerializeField] public GameObject model_low_live;
    [SerializeField] public GameObject model_subrallado;
    [SerializeField] public GameObject curacion;
    [SerializeField] public GameObject gato_enfadado;


    private bool imDead;

    public Material DefaultMaterial => defaultMaterial;
    public Material ReadyToSellMaterial => readyToSellMaterial;

    public bool _shouldEat { private set; get; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentHunger = _maxHunger;
        _shouldEat = true;
        imDead = false;
    }


    private void Update()
    {
        SliderHungerCat.value = _currentHunger;
        _currentHunger -= _hungerDepletionRate * Time.deltaTime;

        // Cambiar esta línea para ajustar al valor necesario para actualizar LevelManager info, en este caso 50% 
        if (LevelManager.Instance.SalesModeActivated)
        {
            if (_currentHunger < _maxHunger / 2)
            {
                modelOutline_shell.SetActive(true);
                modelNoOutline.SetActive(true);
                model_low_live.SetActive(false);
            }
        }

        if (LevelManager.instance.SalesModeActivated == false)
        {
            model_low_live.SetActive(false);
            modelOutline_shell.SetActive(false);
            modelNoOutline.SetActive(true);
        }


        if (_currentHunger <= 0 && !imDead)
        {
            imDead = true;
            _currentHunger = 0;
            LevelManager.Instance.RemoveCatToList(this);
            LevelManager.Instance.AddDeceasedCats();
            Destroy(gameObject);
            return;
        }


        if (_currentHunger <= 50f)
        {
            model_low_live.SetActive(true);
            gato_enfadado.SetActive(true);
            modelOutline_shell.SetActive(false);
        }

        if (_currentHunger >= 50f)
        {
            model_low_live.SetActive(false);
            modelNoOutline.SetActive(true);
            gato_enfadado.SetActive(false);
        }
    }

    public void ReplenishHunger(float hungerAmount)
    {
        curacion.SetActive(true);
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;

        // Cambiar esta línea para ajustar al valor necesario para actualizar LevelManager info, en este caso 50% 
        if (LevelManager.Instance.SalesModeActivated)
        {
            if (_currentHunger > _maxHunger / 2)
            {
                modelOutline_shell.SetActive(true);
                modelNoOutline.SetActive(false);
                model_subrallado.SetActive(false);
            }
        }
    }


    public bool IsReadyToSell()
    {
        // Cambiar esta línea para ajustar al valor necesario para vender el gato, en este caso 50% 
        return _currentHunger > _maxHunger / 2;
    }


    public void ChangMaterial(Material newMaterial)
    {
        modelOutline_shell.SetActive(true);
        modelNoOutline.SetActive(false);
        model_subrallado.SetActive(false);
        model_low_live.SetActive(false);
    }

    public void descativar_curacion()
    {
        curacion.SetActive(false);
    }

    public void Interact()
    {
    }

    public bool InsideTheStore()
    {
        return true;
    }
}