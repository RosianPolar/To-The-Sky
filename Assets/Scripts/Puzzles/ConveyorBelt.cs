using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public List<GameObject> onBelt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i <= onBelt.Count - 1; i++)
        {
            //onBelt[i].GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
            onBelt[i].transform.Translate(direction* Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        onBelt.Add(collision.gameObject);


    } 

    //when something leaves the belt
    private void OnTriggerExit(Collider collision)
    {
        onBelt.Remove(collision.gameObject);
    }
}
