using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] public FireProjectile fireProjectile;
    [SerializeField] private float fireCooldown = 1f;
    private float FireAnother = 0f;

    private void Start()
    {
        
        fireProjectile.SetTargetTF(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //is this how the turret is firing? if so then its trying to fire 60 times a second!
        //fireProjectile.FireAimed();

        if (Time.time >= FireAnother)
        {
            fireProjectile.FireAimed();
            FireAnother = Time.time + fireCooldown;
        }
    }
}
