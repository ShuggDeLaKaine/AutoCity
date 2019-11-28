using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void onPlayClick() // Starts game in Level_1.
    {
        SceneManager.LoadScene("Level_1");
    }

    public void onHelpClick()
    {
        //Code Here.
    }

    public void onExitClick()
    {
        Application.Quit();
    }
}
