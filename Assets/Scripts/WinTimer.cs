using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinTimer : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(30);
        WinGame();
    }

    void WinGame()
    {
        SceneManager.LoadScene("NightOver");
    }
}
