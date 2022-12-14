using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToGame : MonoBehaviour
{

    public void PlayGame()
    {
        // SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex - 1);

        // take player back to game and unpause their progress
        SceneManager.LoadScene("EnemyTesting");
        Time.timeScale = 1f;
       
    }
    
}

