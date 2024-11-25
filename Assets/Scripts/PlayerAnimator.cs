using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator playerAnim55;
    public PlayerController playerController;


    // Start is called before the first frame update
    void awake(){
        playerAnim55 = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //code for walking
        if (Input.GetKey(KeyCode.W))
        {
            playerAnim55.SetBool("Wforward", true);
        }
        else
        {
            playerAnim55.SetBool("Wforward", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim55.SetBool("Sbackward", true);
        }
        else
        {
            playerAnim55.SetBool("Sbackward", false);
        }


        if (Input.GetKey(KeyCode.A))
        {
            playerAnim55.SetBool("Aleft", true);
        }
        else
        {
            playerAnim55.SetBool("Aleft", false);
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            playerAnim55.SetBool("Dright", true);
        }
        else
        {
            playerAnim55.SetBool("Dright", false);
        }

        
        //code for sprinting
        if (Input.GetKey(KeyCode.W) && playerController.SprintingNow == true)
        {
            playerAnim55.SetBool("SPRforward", true);
        }
        else
        {
            playerAnim55.SetBool("SPRforward", false);
        }

        if (Input.GetKey(KeyCode.S) && playerController.SprintingNow == true)
        {
            playerAnim55.SetBool("SPRbackward", true);
        }
        else
        {
            playerAnim55.SetBool("SPRbackward", false);
        }


        if (Input.GetKey(KeyCode.A) && playerController.SprintingNow == true)
        {
            playerAnim55.SetBool("SPRleft", true);
        }
        else
        {
            playerAnim55.SetBool("SPRleft", false);
        }

        
        if (Input.GetKey(KeyCode.D) && playerController.SprintingNow == true)
        {
            playerAnim55.SetBool("SPRright", true);
        }
        else
        {
            playerAnim55.SetBool("SPRright", false);
        }
        
        //code for jumping
        if (playerController.grounded == false)
        {
            playerAnim55.SetBool("JumpBool", true);
        }
        else
        {
            playerAnim55.SetBool("JumpBool", false);
        }

        if (playerController.grounded == false && playerController.SprintingNow == true)
        {
            playerAnim55.SetBool("SPRJumpBool", true);
        }
        else
        {
            playerAnim55.SetBool("SPRJumpBool", false);
        }    
        


    }
}