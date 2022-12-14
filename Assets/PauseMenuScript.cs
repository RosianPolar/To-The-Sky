using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;



    void Start(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        // when escape key is pressed show pause menu
     if (Input.GetKeyDown(KeyCode.Escape))
     {
        if (GameIsPaused)
        {
            Resume();
        }
        else {
            escPause();
        }
     }   
    }

    //resume play
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    //pause the game (used for button UI)
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // pause game (used for escape key)
    void escPause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    // take player to the main game menu 
    public void LoadMenu(){
            SceneManager.LoadScene("Game Menu");
    }
    // take player to item shop
    public void LoadShop(){
        SceneManager.LoadScene("ItemShopScene");
        
    }


    
  
}
