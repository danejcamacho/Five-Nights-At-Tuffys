using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeButton : MonoBehaviour
{
    void Awake()
    {
        //Start button as selected
        GetComponent<Button>().Select();
    }

}
