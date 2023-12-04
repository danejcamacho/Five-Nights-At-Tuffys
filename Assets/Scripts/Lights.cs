using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public void SwitchLight(){ //called by 
        
        StartCoroutine(LightWait());
        
    }
    
    IEnumerator LightWait()
    {
        meshRenderer.enabled = false;
        yield return new WaitForSeconds(3);
        meshRenderer.enabled = true;
        
    }
}
