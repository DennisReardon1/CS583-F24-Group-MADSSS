using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public Animator playerAnim55;
    public PlayerController playerController;

    // Footstep variables
    public AudioSource footstepsSound;
    public AudioSource runstep;
    //code for death grunt vvv
    public AudioSource deathsound;
    private bool hasPlayedDeathSound = false;


    // Start is called before the first frame update
    void Awake(){

        //i initially wanted to do it this way but apparently i get an error if i try doing this.
        //so either leave this alone or prepare to bugfix why the script cannot find these two while
        //they are turned on. for now it defaults to exactly what we needed so leave it alone if you can.

        //playerAnim55 = GetComponent<Animator>();
        //playerController = GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Health check for the DeadDead boolean inside animator
        if (GameManager.gameManager.playerHealth.Health > 0)
        {
            playerAnim55.SetBool("DeadDead", false);  
            //code for death grunt 
            hasPlayedDeathSound = false; 
        }
        else
        {
            playerAnim55.SetBool("DeadDead", true);
            //code for death grunt 
            if (!hasPlayedDeathSound)
            {
                deathsound.Play();
                hasPlayedDeathSound = true;
            }
        }
        

        //code for walking without sprinting
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

        
        //code for sprinting either idle or walking
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
        
        // Footstep logic
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || 
            Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && playerController.grounded)
            {
                footstepsSound.enabled = true;
            }
            else
            {
                footstepsSound.enabled = false;
            }
        if((Input.GetKey(KeyCode.W) && playerController.SprintingNow == true || Input.GetKey(KeyCode.A) && playerController.SprintingNow == true || 
            Input.GetKey(KeyCode.S) && playerController.SprintingNow == true || Input.GetKey(KeyCode.D ) && playerController.SprintingNow == true) && playerController.grounded)
            {
                runstep.enabled = true;
                footstepsSound.enabled = false;
            }
            else
            {
                runstep.enabled = false;
            }


    }
    
}