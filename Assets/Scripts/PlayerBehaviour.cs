using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    private void PlayerGetHurt(int Damage){
        GameManager.gameManager.playerHealth.HurtMe(Damage);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);

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

    }

    private void PlayerGetHealing(int Healing){
        GameManager.gameManager.playerHealth.HealMe(Healing);
        healthBar.SetHealth(GameManager.gameManager.playerHealth.Health);
    }

    //TODO: implement death animation
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

    //NEW: implement respawn mechanic
    //this should should theoretically re-enable movement since it resets the death and hurt trigger
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


}
