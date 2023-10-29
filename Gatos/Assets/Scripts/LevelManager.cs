using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Patrón SINGLETON, para evitar más de una clase igual al mismo tiempo
    public static LevelManager instance;
    public static LevelManager Instance => instance;
    public float SellCatsCount = 0f;
    public float DeceasedCats = 0;



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
        //UIManager.Instance.UpdateInfoNumberOfCats();
    }

    public void AddDeceasedCats() 
    {
        DeceasedCats += 1f;
        UIManager.Instance.UpdateInfoDeceasedCats();
        if (DeceasedCats >= 3)
        {
            UIManager.Instance.LoseCondition();
        }

    }

    public void SellCat(Vida_gatos catToSell)
    {
        RemoveCatToList(catToSell);
        SellCatsCount += 1f;
        UIManager.Instance.UpdateInfoNumberOfSellCats();
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

    public int ReturnCountNumberOfCats()
    {
        return catList.Count;
    }


}
