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
    public Vector3 height = new Vector3(0, 0.01f);

    void Update()
    {
        //Simplifying our previous statement. The player's position is getting assigned and added to by the velocity vector which is declared as a variable beforehand. 
        
        playerMovement();
    }

    private void playerMovement()
    {
        if (Input.GetKey(KeyCode.W)) //Up
        {
            transform.position += height;
        }
        if (Input.GetKey(KeyCode.A)) //Left
        {
            transform.position -= velocity;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            transform.position -= height;
        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            transform.position += velocity;
        }
    }

}
