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

    void Update()
    {
        //Simplifying our previous statement. The player's position is getting assigned and added to by the velocity vector which is declared as a variable beforehand. 
        playerMovement();
    }

    private void playerMovement()
    {
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

        transform.position += moveSpeed * Time.deltaTime * velocity;
    }

}
