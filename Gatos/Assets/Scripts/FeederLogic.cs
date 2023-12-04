using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FeederLogic : MonoBehaviour, I_Interact
{
    [SerializeField] private Food foodPrefab;


    public void Interact()
    {
        Food foodGo = Instantiate(foodPrefab, transform.position, transform.rotation);
        Sound_manager.instance.SeleccionAudio(2, 0.7f);
        foodGo.Interact();
    }

    public bool InsideTheStore()
    {
        return true;
    }
}
