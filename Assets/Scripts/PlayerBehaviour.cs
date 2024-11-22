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
        Animator animator = GetComponent<Animator>();
        if(animator != null)
        {
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
        if(animator != null)
        {
            animator.SetTrigger("isDead");
        }
    }


}
