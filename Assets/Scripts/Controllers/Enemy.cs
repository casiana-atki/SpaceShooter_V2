using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform; 
    public float maxSpeed = 3.0f;
    public float accelerationTime = 1.0f;
    public float decelerationTime = 1.0f;
    private Vector3 currentVelocity = Vector3.zero;
    private float acceleration;
    private float deceleration;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    private void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = playerTransform.position - transform.position;
        float distance = direction.magnitude;

        if (distance > 0.1f) 
        {
            direction.Normalize();
            currentVelocity += direction * acceleration * Time.deltaTime;
        }
        else
        {
            currentVelocity -= currentVelocity.normalized * deceleration * Time.deltaTime;
        }

        if (currentVelocity.magnitude > maxSpeed)
        {
            currentVelocity = currentVelocity.normalized * maxSpeed;
        }

        transform.position += currentVelocity * Time.deltaTime;
    }
}
