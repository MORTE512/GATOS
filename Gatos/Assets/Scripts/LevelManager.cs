using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Patrón SINGLETON, para evitar más de una clase igual al mismo tiempo
    private static LevelManager instance;
    public static LevelManager Instance => instance;


    [SerializeField] private List<Vida_gatos> catList = new List<Vida_gatos>();
    
    private bool salesModeActivated;
    public bool SalesModeActivated
    {
        get => salesModeActivated;
        set => salesModeActivated = value;
    }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        catList = FindObjectsOfType<Vida_gatos>().ToList();
    }

    public void RemoveCatToList(Vida_gatos catToRemove)
    {
        catList.Remove(catToRemove);
    }

    public void SellCat(Vida_gatos catToSell)
    {
        RemoveCatToList(catToSell);
        Destroy(catToSell.gameObject);
        DisableCatsReadyToSell();
    }

    public void ShowCatsReadyToSell()
    {
        int catsReadyToSell = 0;
        
        foreach (var cat in catList)
        {
            if (cat.IsReadyToSell())
            {
                cat.ChangMaterial(cat.ReadyToSellMaterial);
                catsReadyToSell++;
            }
        }

        salesModeActivated = catsReadyToSell > 0;
    }

    public void DisableCatsReadyToSell()
    {
        foreach (var cat in catList)
        {
            if (cat.IsReadyToSell())
            {
                cat.ChangMaterial(cat.DefaultMaterial);
            }
        }
        salesModeActivated = false;
    }
    
}
