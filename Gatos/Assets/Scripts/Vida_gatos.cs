using UnityEngine;
using UnityEngine.UI;

public class Vida_gatos : MonoBehaviour, I_Interact
{
    [Header("Hunger")]
    [SerializeField] public float _maxHunger = 100f;
    [SerializeField] public float _hungerDepletionRate = 1f;
    [SerializeField] private float _currentHunger;
    public Slider SliderHungerCat;


    [Space]
    [Header("---- FEEDBACK MATERIALS ----")]
    private MeshRenderer _meshRenderer;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material readyToSellMaterial;
    [SerializeField] private GameObject modelNoOutline;
    [SerializeField] private GameObject modelOutline;

    public Material DefaultMaterial => defaultMaterial;
    public Material ReadyToSellMaterial => readyToSellMaterial;

    public bool _shouldEat {private set; get;}

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentHunger = _maxHunger;
        _shouldEat = true;
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
                modelOutline.SetActive(true);
                modelNoOutline.SetActive(false);
            }
        }
        
        if (_currentHunger <= 0)
        {
            _currentHunger = 0;
            LevelManager.Instance.RemoveCatToList(this);
            LevelManager.Instance.AddDeceasedCats();
            Destroy(gameObject);

        }

    }
    public void ReplenishHunger(float hungerAmount)
    {
        _currentHunger += hungerAmount;
        if (_currentHunger > _maxHunger) _currentHunger = _maxHunger;

        // Cambiar esta línea para ajustar al valor necesario para actualizar LevelManager info, en este caso 50% 
        if (LevelManager.Instance.SalesModeActivated)
        {
            if (_currentHunger > _maxHunger / 2)
            {
                modelOutline.SetActive(true);
                modelNoOutline.SetActive(false);
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
        modelOutline.SetActive(true);
        modelNoOutline.SetActive(false);
    }
    
    

    public void Interact()
    {
    }
}
