using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    private Transform player;
    public Transform body, turret; 
    public float firingRange;
    public GameObject projectile;
    public float bulletVelocity;
    public float fireRate, nextFire;
    private Animator anim;

    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    public float radius;
    [Range(0, 360)]
    public float angle;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        StartCoroutine(FOVRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(canSeePlayer)
        {
            body.LookAt(player);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();
            }
               
        }
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

 
    void Shoot()
    {
        GameObject clone = Instantiate(projectile, turret.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(body.forward * bulletVelocity);
    }
}
