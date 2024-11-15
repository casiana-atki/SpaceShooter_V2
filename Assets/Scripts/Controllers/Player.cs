using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Transform> asteroidTransforms;
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public Transform bombsTransform;

    //J3: Task 1A Variables
    public Vector3 velocity = new Vector3(0.01f, 0);
    public float moveSpeed = 0.1f;
    //J3: Task 1B Variables
    public float maxSpeed = 5.0f;
    public float accelerationTime = 0.5f;
    public float acceleration; 
    private Vector3 currentVelocity = Vector3.zero;
    //J3: Task 1C Variables
    public float decelerationTime = 1.0f; 
    public float deceleration;


    //J4: Task 1 Variables
    public float radius = 2.0f;
    int circlePoints = 8;
    //J4: Task 2 Variables
    public GameObject powerupPrefab; 

    LineRenderer lineRenderer; 

    private void Start()
    {
        //J3: Task 1B - calculating acceleration
        acceleration = maxSpeed / accelerationTime;
        //J3: Task 1C - calculating deceleration
        deceleration = maxSpeed / decelerationTime;


        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = circlePoints + 1;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        lineRenderer.startColor = Color.green;
        lineRenderer.endColor = Color.green;

        SpawnPowerups(radius, 5); 
    }

    void Update()
    {
        //J3: Simplifying our previous statement. The player's position is getting assigned and added to by the velocity vector which is declared as a variable beforehand. 
        playerMovement();
        EnemyRadar(radius, circlePoints);

        //Assignment 1 Task 1
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnBombGrid(transform.position, 1.0f);
        }
    }

    private void playerMovement()
    {
        bool isInputActive = false;
        //J3: Task 1A - Velocity
        if (Input.GetKey(KeyCode.W)) //Up
        {
            velocity += Vector3.up;
            isInputActive = true;
        }
        if (Input.GetKey(KeyCode.A)) //Left
        {
            velocity += Vector3.left;
            isInputActive = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            velocity += Vector3.down;
            isInputActive = true;
        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            velocity += Vector3.right;
            isInputActive = true;
        }

        //J3: Task 1B - Acceleration
        if (velocity.magnitude > 1)
        {
            velocity.Normalize(); 
        }

        if (isInputActive == true)
        {
            currentVelocity += velocity * acceleration * Time.deltaTime;
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
        //Debug.Log("Current Velocity: " + currentVelocity.magnitude);
    }

    //J4: Task 1
    public void EnemyRadar (float radius, int circlePoints)
    {
        bool enemyWithinRadius = Vector3.Distance(transform.position, enemyTransform.position) <= radius; 
        Color circleColor = enemyWithinRadius ? Color.red : Color.green;
        lineRenderer.startColor = circleColor;
        lineRenderer.endColor = circleColor;
        DrawCircle(transform.position, radius, circlePoints); 
    }

    private void DrawCircle(Vector3 position, float radius, int points)
    {

        for (int i = 0; i <= points; i++)
        {
            float angle = i * Mathf.PI * 2 / points;
            Vector3 point = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            lineRenderer.SetPosition(i, position + point); 
        }
    }

    //J4: Task 2 
    public void SpawnPowerups(float radius, int numberOfPowerups)
    {
        for (int i = 0; i < numberOfPowerups; i++)
        {
            float angle = i * (360f / numberOfPowerups);
            float randomRadius = Random.Range(radius * 0.8f, radius);
            Vector3 spawnPosition = new Vector3(transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * randomRadius, transform.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * randomRadius, transform.position.z);
            Instantiate(powerupPrefab, spawnPosition, Quaternion.identity); 
        }
    }

    //Assignment 1 Task 1
    public void SpawnBombGrid(Vector3 centerPosition, float spacing)
    {
        GameObject[] existingBombs = GameObject.FindGameObjectsWithTag("Bomb");
        foreach (GameObject bomb in existingBombs)
        {
            Destroy(bomb);
        }

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                Vector3 offset = new Vector3(i * spacing, j * spacing, 0); 
                Vector3 bombPosition = new Vector3(centerPosition.x + offset.x, centerPosition.y + offset.y, centerPosition.z);
                Instantiate(bombPrefab, bombPosition, Quaternion.identity);
            }
        }
    }
}
