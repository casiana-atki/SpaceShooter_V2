using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public Transform planetTransform;
    private float angle; 

    void Start()
    {
        angle = 0f; 
    }

    void Update()
    {
        OrbitalMotion(5f, 1f * Time.deltaTime, planetTransform); 
    }

    public void OrbitalMotion(float radius, float speed, Transform target)
    {
        angle += speed;

        float x = target.position.x + Mathf.Cos(angle) * radius;
        float y = target.position.y + Mathf.Sin(angle) * radius; 

        transform.position = new Vector3(x, y, transform.position.z);
    }
}
