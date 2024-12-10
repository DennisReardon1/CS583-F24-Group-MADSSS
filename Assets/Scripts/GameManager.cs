using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager {get; private set;}

    public UnitHealth playerHealth = new UnitHealth(100,100);

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quit the game!");
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Tab))
        {
            Debug.Log("CHANGING SCENES");
            SceneManager.LoadScene("MainMenuScene");
        }
    }


}
