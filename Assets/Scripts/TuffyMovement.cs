using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TuffyMovement : MonoBehaviour
{
    //Tuffy path is Cams 7, 5, Office
   int tuffyCurrIndex;
   int randTime;
   [SerializeField] int rStartTime, rEndTime;

   [SerializeField] DoorMovement leftDoor;
   [SerializeField] DoorMovement rightDoor;

   [SerializeField] GameObject[] tuffyPositions;

   [SerializeField] CameraSwitcher cams;
   [SerializeField] GameObject doorsAndCams;
   [SerializeField] Animator tuffyAnim;
   [SerializeField] AudioSource tuffyAudio;


   private void Start() {
        tuffyCurrIndex = 0;
        randTime = Random.Range(rStartTime, rEndTime);
        tuffyPositions[0].SetActive(true);
        StartCoroutine(TuffyMoveTimer());
    }

   
    
    IEnumerator TuffyMoveTimer(){
        yield return new WaitForSeconds(randTime);
        TuffyMove();
    }

    void TuffyMove(){
        switch(tuffyCurrIndex) 
        {
            case 0:
                tuffyCurrIndex++;
                randTime = Random.Range(rStartTime, rEndTime);
                //Move to Cam 5
                tuffyPositions[0].SetActive(false);
                tuffyPositions[1].SetActive(true);

                StartCoroutine(TuffyMoveTimer());
                break;
            case 1:
                tuffyCurrIndex++;
                randTime = Random.Range(rStartTime, rEndTime);
                //Move to Office
                tuffyPositions[1].SetActive(false);
                tuffyPositions[2].SetActive(true);

                StartCoroutine(TuffyMoveTimer());
                break;
            case 2:
                tuffyPositions[2].SetActive(false);
                tuffyPositions[0].SetActive(true);
                //If Ldoor is closed, set index back to 0 after a time
                if (leftDoor.isOpen == false){
                    tuffyCurrIndex = 0;
                    randTime = Random.Range(rStartTime, rEndTime);
                    StartCoroutine(TuffyMoveTimer());
                }
                else{
                    TuffyAttack();
                }
                break;
            default:
                Debug.Log("Something went wrong in TuffyMove()!");
                break;
        }

    }

    void TuffyAttack(){
        Debug.Log("Tuffy is attacking!");
        //Set camera back to office
        cams.ChangeCamera(0);

        //Turn off DoorsAndCams
        doorsAndCams.SetActive(false);

        //Play tuffy attack animation
        tuffyAnim.SetTrigger("Attack");
        StartCoroutine(AfterAttackTimer());

        //Play tuffy atttack sound
        tuffyAudio.Play();

    }

    IEnumerator AfterAttackTimer(){
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("MainMenu");
    }


}
