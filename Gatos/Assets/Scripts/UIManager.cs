using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;

    [SerializeField] private GameObject panelClientDialog;

    
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
}
