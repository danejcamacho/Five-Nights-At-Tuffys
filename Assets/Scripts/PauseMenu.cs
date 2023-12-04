using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;



    // Update is called once per frame
    void Update()
    {
        //if escape is pressed, pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if the game is already paused, unpause it
            if (Time.timeScale == 0)
            {
                pauseMenu.enabled = false;

                Time.timeScale = 1;
            }
            //if the game is not paused, pause it
            else
            {
                pauseMenu.enabled = true;
                
                Time.timeScale = 0;
            }
        }
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
