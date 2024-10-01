using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed;
    public float arrivalDistance;
    public float maxFloatDistance;
    private Vector3 targetPosition;

    void Start()
    {
        ChooseNewTarget();
    }

    void Update()
    {
        MoveTowardsTarget();
    }

    private void ChooseNewTarget()
    {
        float randomX = Random.Range(-maxFloatDistance, maxFloatDistance);
        float randomY = Random.Range(-maxFloatDistance, maxFloatDistance);
        targetPosition = transform.position + new Vector3(randomX, randomY, 0);
    }

    private void MoveTowardsTarget()
    {
        if (Vector3.Distance(transform.position, targetPosition) <= arrivalDistance)
        {
            ChooseNewTarget();
        }
        else
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
