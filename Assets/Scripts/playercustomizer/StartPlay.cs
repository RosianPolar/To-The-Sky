using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPlay : MonoBehaviour
{
    // go from choose player menu to game
    public void Play()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1);
    }
}
