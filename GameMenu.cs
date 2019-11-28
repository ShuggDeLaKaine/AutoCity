using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour {

    public GameObject panel;
    bool state;

    public void toggleMenu()
    {
        state = !state;
        panel.gameObject.SetActive(state);

    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            toggleMenu();
        }
    }

}
