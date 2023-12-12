using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClientSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] clientsPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minTimeToSpawn;
    [SerializeField] private float maxTimeToSpawn;
    [SerializeField] private float maxClients;
    
    private float _currentClients;

    private void Start()
    {
        StartCoroutine(SpawnerClients());
    }


    IEnumerator SpawnerClients()
    {
        while (true)
        {
            if (_currentClients < maxClients)
            {

                _currentClients++;
                float randomTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
                yield return new WaitForSeconds(randomTime);
                int randomIndex = Random.Range(0, spawnPoints.Length);

                int randomIndexClients = Random.Range(0, clientsPrefab.Length);
                Instantiate(clientsPrefab[randomIndexClients], spawnPoints[randomIndex].transform.position,
                    spawnPoints[randomIndex].transform.rotation);
                
            }
            yield return new WaitForSeconds(0.5f);
        }
    }


    public void SubtractClient()
    {
        _currentClients--;
    }


}
