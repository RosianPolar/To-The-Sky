using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{
    private Transform player;
    private float distanceToPlayer;
    public Transform body, turret; 
    public float firingRange;
    public GameObject projectile;
    public float bulletVelocity;
    public float fireRate, nextFire;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if(distanceToPlayer <= firingRange)
        {
            body.LookAt(player);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                Shoot();
            }
               
        }
    }

    void Shoot()
    {
        GameObject clone = Instantiate(projectile, turret.position, transform.rotation);
        clone.GetComponent<Rigidbody>().AddForce(body.forward * bulletVelocity);
        Destroy(clone, 15);
    }
}
