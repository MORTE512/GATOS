using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class WPClientsManager : MonoBehaviour
{
    private static WPClientsManager _instance;
    public static WPClientsManager Instance => _instance;

    [SerializeField] private Transform[] wpClients;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public Transform ReturnRandomWp()
    {
        int randomIndex = Random.Range(0, wpClients.Length);
        return wpClients[randomIndex];
    }

}
