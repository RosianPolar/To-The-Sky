using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPos : MonoBehaviour
{
    private CheckPointControls gm;

    // Start is called before the first frame update
    void Start()
    {
        // create checkpoint control object
        gm = GameObject.FindGameObjectWithTag("CheckPoint").GetComponent<CheckPointControls>();
        transform.position = gm.lastCheckPointPos;
    }

    // Update is called once per frame
    void Update()
    {
        // temporary way for player to die when space key is pressed for testing
     if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }   
    }
}
