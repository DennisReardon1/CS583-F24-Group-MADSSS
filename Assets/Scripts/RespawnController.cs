using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private Transform PillPlayer;
    [SerializeField] public Transform RespawnPoint;
    void OnTriggerEnter(Collider other)
    {
        
        PillPlayer.transform.position = RespawnPoint.transform.position;
    }
}
