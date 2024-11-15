using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    public PlayerController playerController22;

    private void OnTriggerEnter(Collider other){
        if(other.gameObject == playerController22.gameObject)
            return;
        
        playerController22.SetGrounded(true);
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject == playerController22.gameObject)
            return;
        
        playerController22.SetGrounded(false);
    }

    private void OnTriggerStay(Collider other){
        if(other.gameObject == playerController22.gameObject)
            return;
        
        playerController22.SetGrounded(true);
    }

}
