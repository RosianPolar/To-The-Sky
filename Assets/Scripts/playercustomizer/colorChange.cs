using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public GameObject colorSelection;
    // change selected color depending on what button user clicks
    public void selectColor(){
        loadSkin.color = colorSelection;
    }
}
