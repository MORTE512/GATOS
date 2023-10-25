using UnityEngine;

public class RecogerComida : MonoBehaviour
{
    public static RecogerComida instance;

    [Tooltip("Posici�n donde la comida se recoger�")]
    [SerializeField] private Transform _foodPosition;

    private Food _foodGetted;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    /// <summary>
    /// M�todo para recoger la comida;
    /// </summary>
    /// <param name="food"></param>
    public void PickUp(Food food)
    {
        if (_foodGetted != null)
        {
            return;
        }
        
        _foodGetted = food;
        _foodGetted.rb.isKinematic = true;
        _foodGetted.transform.SetParent(_foodPosition);
        _foodGetted.transform.localPosition = Vector3.zero;
    }

    /// <summary>
    /// M�todo para soltar la comida;
    /// </summary>
    public void Throw()
    {
        if (_foodGetted == null) 
        {
            return;
        }

        _foodGetted.transform.SetParent(null);
        _foodGetted.rb.isKinematic = false;
        _foodGetted = null;
    }
}    
    

