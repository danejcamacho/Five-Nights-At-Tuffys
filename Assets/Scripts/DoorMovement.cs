using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    public bool isOpen = true;
    float speed = 0.3f;

    bool canChange = true;

    Vector3 openPosition;
    Vector3 closedPosition;
   
    void Start()
    {
        openPosition = transform.position;
        closedPosition = new Vector3(transform.position.x, transform.position.y - 9, transform.position.z);
    }

    public void ChangeDoor()
    {
        if (isOpen)
        {
            StartCoroutine(MoveObject(openPosition, closedPosition, speed));
            isOpen = false;
            StartCoroutine(ReOpenDoor());

            
        }
        else if( canChange)
        {
            StartCoroutine(MoveObject(closedPosition, openPosition, speed));
            isOpen = true;
        }
        
    }

    IEnumerator MoveObject(Vector3 source, Vector3 target, float overTime)
{
    float startTime = Time.time;
    while(Time.time < startTime + overTime)
    {
        transform.position = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
        yield return null;
    }
    transform.position = target;
}
    IEnumerator ReOpenDoor(){
        canChange = false;
        yield return new WaitForSeconds(5);
        canChange = true;
        ChangeDoor();
    }
}  
