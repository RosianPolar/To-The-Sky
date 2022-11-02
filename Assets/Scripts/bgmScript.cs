using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmScript : MonoBehaviour
{
    public static bgmScript instance;

    void Awake() {
        if(instance != null) {
            Destroy(gameObject);
        }
        
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }   
        
    }
}
