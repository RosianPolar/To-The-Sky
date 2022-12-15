using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class demoLevelAdvancement : MonoBehaviour
{

    public string nextLevel;
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextLevel);
        }
    }
}
