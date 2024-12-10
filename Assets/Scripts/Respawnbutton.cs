using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawnbutton : MonoBehaviour
{
    [SerializeField] private Transform PillPlayer;
    [SerializeField] public Transform RespawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //PlayerBehaviour.Respawn();
            //PillPlayer.transform.position = RespawnPoint.transform.position;
            PillPlayer.transform.position = RespawnPoint.transform.position;
        }
    }

}//END
