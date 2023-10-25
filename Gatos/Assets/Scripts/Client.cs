using UnityEngine;

public class Client : MonoBehaviour, I_Interact
{
    public void Interact()
    {
        UIManager.Instance.ShowClientDialog();
    }
}
