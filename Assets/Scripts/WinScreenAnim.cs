using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WinScreenAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fiveAm;
    [SerializeField] TextMeshProUGUI sixAm;

    private void Start() {
        sixAm.canvasRenderer.SetAlpha(0.0f);
        // fade to transparent over 500ms.
        fiveAm.CrossFadeAlpha(0.0f, 1f, false);
        StartCoroutine(Wait());
        // and back over 500ms.
        
    }
    IEnumerator Wait(){
        yield return new WaitForSeconds(1);
        sixAm.CrossFadeAlpha(1.0f, 1.5f, false);
        StartCoroutine(Wait2());
    }
    
    IEnumerator Wait2(){
        yield return new WaitForSeconds(3);
        ChooseNextNight();
    }

    void ChooseNextNight(){
        switch(PlayerPrefs.GetString("CurrentNight")){
            case "Night1":
                PlayerPrefs.SetString("CurrentNight", "Night2");
                SceneManager.LoadScene("Night2");
                break;
            //Add to this when making more nights
        }
    }
}
