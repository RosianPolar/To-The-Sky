using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    private CheckPointControls gm;

    void Start()
    {
       // create checkpoint control object
        gm = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPointControls>();
    }

    // when player falls off the plane they trigger the respawn function
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            player.transform.position = gm.lastCheckPointPos;
            Physics.SyncTransforms();
        }
    }

}
