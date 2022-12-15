using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    public CheckPointControls checkpoint;

    void Start()
    {
       // create checkpoint control object
        checkpoint = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPointControls>();
    }

    // when player gets hit by enemy they trigger the respawn function
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            player.transform.position = checkpoint.lastCheckPointPos;
            Physics.SyncTransforms();
        }
        
    }


}
