using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] private RespawnController respawnController;
    public Animator playerAnim55;
    public PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //dev commands to hurt and heal the player manually.
         if (Input.GetKeyDown(KeyCode.H))
         {
            PlayerGetHurt(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
         }
         if (Input.GetKeyDown(KeyCode.U))
         {
            PlayerGetHealing(20);
            Debug.Log(GameManager.gameManager.playerHealth.Health);
         }
         //NEW: Respawn player when pressing R
         if (Input.GetKeyDown(KeyCode.R))
         {
            Respawn();
            Debug.Log("Player Respawned");
         }
    }

    public void PlayerGetHurt(int Damage){
        GameManager.gameManager.playerHealth.HurtMe(Damage);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);

        //are you dead?
        if (GameManager.gameManager.playerHealth.Health <= 0)
        {
            playerAnim55.SetTrigger("isDead");
            return;
        }
        //you got hurt but not dead yet.
        playerAnim55.SetTrigger("isHurt");

        //code that is no longer needed to animate getting hit and dying.
        /*
        //NEW: Play hurt animation whenever player takes damage
        //NOTE: May have to change this to apply to whenever player collides with 
        //environmental hazard
        Animator animator = GetComponent<Animator>();
        if(animator != null)
        {
            
            Debug.Log("Got hurt");
            animator.SetTrigger("isHurt");
        }
        //NEW: Trigger PlayerDeath if HP reaches 0
        if(GameManager.gameManager.playerHealth.Health <= 0)
        {
            PlayerDeath();
        }
        Debug.Log("PlayerGetHurt");
        */

    }//PlayerGetHurt

    private void PlayerGetHealing(int Healing){
        GameManager.gameManager.playerHealth.HealMe(Healing);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        
        if (GameManager.gameManager.playerHealth.Health > 0)
        {
            playerAnim55.ResetTrigger("isDead");
        }

    }//PlayerGetHealing

    
    //this isnt needed anymore, if you want player to die just use the playergethurt method. - Dennis
    /*
    private void PlayerDeath()
    {
        Debug.Log("Player Has Died");
        Animator animator = GetComponent<Animator>();
        PlayerController playerController = GetComponent<PlayerController>();
        if(playerController != null)
        {
            playerController.SetDead(true);
        }
        if(animator != null)
        {
            Debug.Log("Playing Death animation...");
            animator.SetTrigger("isDead");
        }
    }
    */
    

    //MIKKO
    //this should should theoretically re-enable movement since it resets the death and hurt trigger
    //turning this off shortterm until the branch merges and hit/deaths is patched. - Dennis
    /*
    public void Respawn()
    {
        PlayerController playerController = GetComponent<PlayerController>();
        Animator animator = GetComponent<Animator>();

        if (playerController != null)
        {
            playerController.SetDead(false); // Mark the player as alive
        }

        if (animator != null)
        {
            animator.ResetTrigger("isDead"); // Reset death animation
        }
    }
    */

    public void Respawn()
    {
        //Reset player health to full  
        PlayerGetHealing(100);

        //Reset player position to respawn point
        transform.position = respawnController.RespawnPoint.transform.position;
        transform.rotation = respawnController.RespawnPoint.transform.rotation;

        //Reset animation triggers (testing, may be irrelevant)
        playerAnim55.ResetTrigger("isDead");
        playerAnim55.ResetTrigger("isHurt");

        //Re-enable player control
        playerController.SetDead(false);

    }

    //Sheng Trap Trigger if entering its space.
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "FireTrap")
        {
            //getting hurt by 100 damage would do the same thing if you want instant death.
            //also fyi, the player can never go beyond 100 or below 0 so dont think too hard on that.
            //PlayerDeath();
            PlayerGetHurt(100);
            Debug.Log(GameManager.gameManager.playerHealth.Health); //shows the players current health
        }
        if (collider.tag == "SpikeTrap")
        {
            PlayerGetHurt(40);
            Debug.Log(GameManager.gameManager.playerHealth.Health); //shows the players current health
        }
    }//OnTriggerEnter

}//END