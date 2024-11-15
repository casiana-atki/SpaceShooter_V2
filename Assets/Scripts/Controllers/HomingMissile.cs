using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This entire script is just for Assignment 1 Task 3 - Homing Missile
public class HomingMissile : MonoBehaviour
{
    public Transform enemyTransform;  
    public float speed = 5.0f; 
    public float turnSpeed = 200f;  
    public float homingRange = 0.1f; 

    private void Start()
    {
    }

    private void Update()
    {
        if (enemyTransform != null)
        {
            Vector3 direction = enemyTransform.position - transform.position;
            float distance = direction.magnitude;
            direction.Normalize();


            Quaternion lookRotation = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);

            transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);

            if (distance <= homingRange)
            {
                Destroy(gameObject);  
            }
        }
    }
}
