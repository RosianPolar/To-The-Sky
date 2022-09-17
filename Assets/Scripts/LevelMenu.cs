using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public void earthLevel() {
        SceneManager.LoadScene("earthLevel");
    }

    public void fireLevel() {
        SceneManager.LoadScene("fireLevel");
    }

    public void waterLevel() {
        SceneManager.LoadScene("waterLevel");
    }

    public void airLevel() {
        SceneManager.LoadScene("airLevel");
    }

}
