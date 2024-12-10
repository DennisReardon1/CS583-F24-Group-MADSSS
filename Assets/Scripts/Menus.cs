using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour
{
    //have a main menu that just has buttons to all the levels, can get to them anyway the normal way.
    
    public void Level1(){
        SceneManager.LoadScene("AlbertoLevel");
    }
    public void Level2(){
        SceneManager.LoadScene("Alberto Level 2");
    }
    public void Level3(){
        SceneManager.LoadScene("sreehith Level 3");
    }   

    public void Level4(){
        SceneManager.LoadScene("Winner room Sadia");
    } 

    public void QuitGame(){
        Application.Quit();
    }


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    /*
    public void TempA(){
        Cursor.lockState = CursorLockMode.Locked
    }
    */
}
