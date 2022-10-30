using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private CheckPointControls gm;
    // Start is called before the first frame update
    void Start()
    {
        // create checkpoint control object
        gm = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPointControls>();
    }

    // when player touches a checkpoint the lastCheckPointPosition updates to the new one
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            gm.lastCheckPointPos = transform.position;
        }
        
    }
}
