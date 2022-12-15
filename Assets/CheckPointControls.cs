using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointControls : MonoBehaviour
{
    
    private static CheckPointControls instance;
    public Vector3 lastCheckPointPos;
    void Awake(){
        // check if a checkPointControls object has been created
        if(instance == null){
            instance = this;
            // dont reset level information when scene is loaded again
            DontDestroyOnLoad(instance);
        }else{
            // get rid of new CheckPointControls object if there is already one made
            Destroy(gameObject);
        }
    }
}
