using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour, I_Interact
{
    [SerializeField] private float minTimeIdle;
    [SerializeField] private float maxTimeIdle;

    private NavMeshAgent _navMeshAgent;
    private Transform _target;
    private bool _imWalking;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = WPClientsManager.Instance.ReturnRandomWp();
        _imWalking = true;
    }


    private void Update()
    {
        if (_imWalking)
        {
            _navMeshAgent.SetDestination(_target.position);
            if (_navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                _imWalking = false;
                StartCoroutine(IdlePlayer());
            }
        }
    }


    IEnumerator IdlePlayer()
    {
        float randomIdleTime = Random.Range(minTimeIdle, maxTimeIdle);
        yield return new WaitForSeconds(randomIdleTime);
        _target = WPClientsManager.Instance.ReturnRandomWp();
        _imWalking = true;
    }


    public void Interact()
    {
        UIManager.Instance.ShowClientDialog();
    }
}