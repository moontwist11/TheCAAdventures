using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooseMovement : MonoBehaviour
{
    int position;
    int maxPosition;
    bool movementAllowed;

    void Start() {
        position = 0;
        maxPosition = 7;
        movementAllowed = true;
    }
    
    IEnumerator movementDelay() {
        yield return new WaitForSeconds(0.10f);
        movementAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPosition = this.transform.position;
        if(Input.GetAxis("Horizontal") < 0 && position != 0 && movementAllowed){
            newPosition.x -= 2;
            position--;
            movementAllowed = false;
            StartCoroutine(movementDelay());
        }
        if(Input.GetAxis("Horizontal") > 0 && position != maxPosition && movementAllowed){
            newPosition.x +=2;
            position++;
            movementAllowed = false;
            StartCoroutine(movementDelay());
        }

        this.transform.position = newPosition;
    }
}
