using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag != "Bullet")
        {
            gameObject.transform.parent = collision.gameObject.transform;
            Destroy(GetComponent<Rigidbody>());
            GetComponent<Collider>().enabled = false;
        } 

        if(collision.tag == "Player")
        {

            var healthComponent = collision.GetComponent<Health>();
            if(healthComponent != null)
            {
                healthComponent.TakeDamage(2);
            }
        }
    }
}
