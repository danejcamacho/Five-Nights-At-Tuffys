using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    public int currentCameraIndex;
    public void ChangeCamera(int camNum){
        if(camNum == currentCameraIndex){
            return;
        }
        Debug.Log("Switching to Camera " + camNum);
        cameras[camNum].enabled = true;
        cameras[currentCameraIndex].enabled = false;
        currentCameraIndex = camNum;

        //move the cams over if its the office cam
        if(currentCameraIndex == 0){
            Debug.Log(transform.position);
            transform.position = new Vector3(860, 669, 0);
        }
        else{
            transform.position = new Vector3(1200, 669, 0);
        }

    }

}
