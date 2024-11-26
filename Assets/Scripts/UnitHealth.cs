using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth
{
    private int currHealth;
    private int maxHealth;

    //getter and setters
    public int Health{
        get{
            return currHealth;
        }
        set{
            currHealth = value;
        }
    }//currentHealth


    public int MaxyHealth{
        get{
            return maxHealth;
        }
        set{
            maxHealth = value;
        }
    }//maxHealth

    public UnitHealth(int health1, int maxHealth1){
        currHealth = health1;
        maxHealth = maxHealth1;
    }
    
    public void HurtMe(int Damage){
        if(currHealth > 0){
            currHealth = currHealth - Damage;
        }
        if (currHealth < 0)
        {
            currHealth = 0;
        }
    }


    public void HealMe(int Healing){
        if(currHealth < maxHealth){
            currHealth = currHealth + Healing;
        }
        if(currHealth > maxHealth){
            currHealth = maxHealth;
        }
    }

}//END

