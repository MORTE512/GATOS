using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Client : MonoBehaviour, I_Interact
{
    [SerializeField] private float minTimeIdle;
    [SerializeField] private float maxTimeIdle;

    [SerializeField] private NavMeshAgent _navMeshAgent;
    private Transform _target;
    public Animator animator;
    public bool clientBuyCat;
    

    private int counterRemainingDistance;

    private bool courotineActive = false;

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _target = WPClientsManager.Instance.ReturnRandomWp();
        animator.SetBool("walking", true);
        clientBuyCat = false;
    }

    private void Update()
    {
        if (clientBuyCat) return;

        _navMeshAgent.SetDestination(_target.position);
        if (Vector3.Distance(transform.position, _target.transform.position) < 2f)
        {
            counterRemainingDistance++;
             
            if (!courotineActive)
                StartCoroutine(IdlePlayer());
        }
             
    }

    IEnumerator IdlePlayer()
    {
        if (counterRemainingDistance < 2)
        {
            yield break;
        }

        courotineActive = true;
        animator.SetBool("walking", false);
        _navMeshAgent.isStopped = true;
        float randomIdleTime = Random.Range(minTimeIdle, maxTimeIdle);
        yield return new WaitForSeconds(randomIdleTime);
        _target = WPClientsManager.Instance.ReturnRandomWp();
        courotineActive = false;
        _navMeshAgent.isStopped = false;
        animator.SetBool("walking", true);

    }

   
    public void ClientBuyCat()
    {
        clientBuyCat = true;
        StopAllCoroutines();
        _navMeshAgent.isStopped = false;
        animator.SetBool("walking", true);
        _navMeshAgent.SetDestination(WPClientsManager.Instance.ReturnRandomExitWp().transform.position);
    }


    public void Interact()
    {
        if (clientBuyCat) return;

        UIManager.Instance.ShowClientDialog();
        LevelManager.instance.clientSelected = this;
    }
}

