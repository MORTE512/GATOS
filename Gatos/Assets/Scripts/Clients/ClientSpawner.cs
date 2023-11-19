using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ClientSpawner : MonoBehaviour
{

    [SerializeField] private GameObject clientPrefab;
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
                float randomTime = Random.Range(minTimeToSpawn, maxTimeToSpawn);
                yield return new WaitForSeconds(randomTime);
                int randomIndex = Random.Range(0, spawnPoints.Length);

                Instantiate(clientPrefab, spawnPoints[randomIndex].transform.position,
                    spawnPoints[randomIndex].transform.rotation);
                
                _currentClients++;
            }
            yield return null;
        }
    }
}
