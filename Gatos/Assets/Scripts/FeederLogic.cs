using UnityEngine;

public class FeederLogic : MonoBehaviour, I_Interact
{
    [SerializeField] private Food foodPrefab;
    
    public void Interact()
    {
        Food foodGo = Instantiate(foodPrefab, transform.position, transform.rotation);
        foodGo.Interact();
    }
}
