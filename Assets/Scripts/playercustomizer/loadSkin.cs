using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// class to load new skin color chosen by user
public class loadSkin : MonoBehaviour
{
    public static GameObject color;
    // based on color selected by player change the character model in the game
    private void Awake(){
        Instantiate(color, transform);
    }
}
