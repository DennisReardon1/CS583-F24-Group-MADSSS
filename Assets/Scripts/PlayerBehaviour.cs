using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    [SerializeField] private Transform RespawnPoint; //NEW: Respawn point for player
    [SerializeField] private Transform PlayerStartingPos;
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

    }//PlayerGetHurt

    private void PlayerGetHealing(int Healing){
        GameManager.gameManager.playerHealth.HealMe(Healing);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
        
        if (GameManager.gameManager.playerHealth.Health > 0)
        {
            playerAnim55.ResetTrigger("isDead");
        }

    }//PlayerGetHealing

    public void Respawn()
    {
        //Reset player health to full  
        PlayerGetHealing(100);

        //Reset player position to respawn point
        PlayerStartingPos.transform.position = RespawnPoint.transform.position;
        PlayerStartingPos.transform.rotation = RespawnPoint.transform.rotation;

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