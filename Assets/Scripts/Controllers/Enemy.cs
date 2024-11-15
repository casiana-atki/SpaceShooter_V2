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
    private bool isRetreating = false;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

        StartCoroutine(RetreatAndReturn());
    }

    private void Update()
    {
        MoveTowardsPlayer(isRetreating ? -1 : 1);
    }

    private void MoveTowardsPlayer(int directionMultiplier)
    {
        Vector3 direction = (playerTransform.position - transform.position) * directionMultiplier;
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

    private IEnumerator RetreatAndReturn()
    {
        while (true)
        {
            yield return new WaitForSeconds(6.0f);
            isRetreating = true;

            yield return new WaitForSeconds(2.0f);
            isRetreating = false;
        }
    }
}
