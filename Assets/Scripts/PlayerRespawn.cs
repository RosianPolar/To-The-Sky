using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    public Transform checkpoint;

    void Start()
    {
       // create checkpoint control object
        checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").transform;
    }

    // when player falls off the plane they trigger the respawn function
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            player.transform.position = checkpoint.position;
            Physics.SyncTransforms();
        }
        
    }


}
