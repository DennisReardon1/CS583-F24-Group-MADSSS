using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingcubeX : MonoBehaviour
{
    public float speed = .5f; // Speed of the obstacle
    public float distance = 2.0f; // Distance to move
    private Vector3 startPosition; // Starting position of the obstacle
    private Rigidbody rb; // Reference to Rigidbody

    void Start()
    {
        // Record the starting position
        startPosition = transform.position;
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Calculate the new position using a sine wave
        float movement = Mathf.Sin(Time.time * speed) * distance;
        Vector3 newPosition = startPosition + new Vector3(movement, 0, 0);

        // Move the Rigidbody
        rb.MovePosition(newPosition);
    }
}
