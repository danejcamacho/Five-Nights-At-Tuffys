using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMngr : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;
    public void NewGame() {
        
        PlayerPrefs.SetString("CurrentNight", "Night1");
        SceneManager.LoadScene("Night1");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Continue() {
        if(PlayerPrefs.GetString("CurrentNight") == "") {
            PlayerPrefs.SetString("CurrentNight", "Night1");
        }
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentNight"));
    }

    public void ShowHideHowToPlay() {
        howToPlay.SetActive(!howToPlay.activeSelf);
    }

}
