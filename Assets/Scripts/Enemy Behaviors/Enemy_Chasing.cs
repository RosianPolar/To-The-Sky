using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Chasing : MonoBehaviour
{
    private int destPoint = 0;
    public Transform[] patrolPoints;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform movePositionTransform;
    [SerializeField] float moveSpeed = 0.25f;

    public float radius;
    [Range(0,360)] public float angle;

    public GameObject playerRef; 

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    
    

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;

        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
        if(patrolPoints != null)
            GoToNextPoint();
    }


    // Update is called once per frame
    void Update()
    {
        if (canSeePlayer)
        {
            //navMeshAgent.isStopped = false;
            navMeshAgent.destination = movePositionTransform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, playerRef.transform.position);
            if (distanceToPlayer <= 1)
            {
                navMeshAgent.isStopped = true;
            }
        }
        else
        {
            if ((!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f) && patrolPoints != null)
                GoToNextPoint();
        }

    }

    void GoToNextPoint()
    {
        //if the enemy just finished chasing the player
        //if (navMeshAgent.isStopped == true) navMeshAgent.isStopped = false;
        // Returns if no points have been set up
        if (patrolPoints.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        navMeshAgent.destination = patrolPoints[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % patrolPoints.Length;
    }

    private IEnumerator FOVRoutine()
    {
        float delay = 0.2f;
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    } 

    
    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;
    }
}
