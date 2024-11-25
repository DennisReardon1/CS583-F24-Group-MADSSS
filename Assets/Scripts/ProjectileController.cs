using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] public FireProjectile fireProjectile;

    private void Start()
    {
        
        fireProjectile.SetTargetTF(GameObject.FindGameObjectWithTag("Player").transform);
    }

    // Update is called once per frame
    void Update()
    {
        fireProjectile.FireAimed();
    }
}
