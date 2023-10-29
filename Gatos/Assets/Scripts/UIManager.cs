using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] private GameObject panelClientDialog;
    //[SerializeField] private TextMeshProUGUI catsCounter;
    [SerializeField] private TextMeshProUGUI contadorSellCatsText;
    [SerializeField] private TextMeshProUGUI DeceasedCatsText;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject WinaPanel;


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

    private void Start()
    {
       // UpdateInfoNumberOfCats();
        UpdateInfoNumberOfSellCats();
        UpdateInfoDeceasedCats();


    }


    public void ShowClientDialog()
    {
        panelClientDialog.SetActive(true);
    }

    public void HideClientDialog()
    {
        panelClientDialog.SetActive(false);
    }

    public bool IsClientDialogPanelActive()
    {
        return panelClientDialog.activeSelf;
    }


    //public void UpdateInfoNumberOfCats()
    //{
      //  catsCounter.text = LevelManager.Instance.ReturnCountNumberOfCats().ToString();
   // }

    public void UpdateInfoNumberOfSellCats()
    {
        contadorSellCatsText.text = LevelManager.instance.SellCatsCount.ToString();
    }

    public void UpdateInfoDeceasedCats()
    {
        DeceasedCatsText.text = LevelManager.instance.DeceasedCats.ToString();
    }

    public void LoseCondition()
    {
        LosePanel.SetActive(true);
    }

    public void WinCondition()
    {
        WinaPanel.SetActive(true);
    }

}
