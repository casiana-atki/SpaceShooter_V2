using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    public Vector3 velocity = new Vector3(0.01f, 0);
    public float moveSpeed = 0.1f;
    public float maxSpeed = 5.0f;
    public float accelerationTime = 0.5f;
    public float acceleration; 
    private Vector3 currentVelocity = Vector3.zero;

    private void Start()
    {
        //Task 1B - calculating acceleration
        acceleration = maxSpeed / accelerationTime; 
    }

    void Update()
    {
        //Simplifying our previous statement. The player's position is getting assigned and added to by the velocity vector which is declared as a variable beforehand. 
        playerMovement();
    }

    private void playerMovement()
    {
        //Task 1A - Velocity
        if (Input.GetKey(KeyCode.W)) //Up
        {
            velocity += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A)) //Left
        {
            velocity += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            velocity += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            velocity += Vector3.right; 
        }

        //Task 1B - Acceleration
        if (velocity.magnitude > 1)
        {
            velocity.Normalize(); 
        }

        if (velocity != Vector3.zero)
        {
            currentVelocity += velocity * acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity = Vector3.Lerp(currentVelocity, Vector3.zero, 0.1f); 
        }

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed; 
        }

        transform.position += currentVelocity * Time.deltaTime;
        //Debug.Log("Current Velocity: " + currentVelocity.magnitude);
    }

}
