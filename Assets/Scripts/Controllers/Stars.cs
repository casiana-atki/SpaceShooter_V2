using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;
    private LineRenderer lineRenderer;
    private int currentIndex = 0;
    private float elapsedTime = 0f;

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.startColor = Color.white; 
        lineRenderer.endColor = Color.white;
        lineRenderer.enabled = false; 
    }

    void Update()
    {
        if (!lineRenderer.enabled)
        {
            StartDrawingLine(); 
        }
        else
        {
            DrawLine(); 
        }
    }

    private void StartDrawingLine()
    {
        lineRenderer.enabled = true;
        elapsedTime = 0f;

        Vector3 startPoint = starTransforms[currentIndex].position;
        Vector3 endPoint = starTransforms[(currentIndex + 1) % starTransforms.Count].position;

        lineRenderer.SetPosition(0, startPoint); 
        lineRenderer.SetPosition(1, startPoint);
    }

    private void DrawLine()
    {
        elapsedTime += Time.deltaTime;
        float t = elapsedTime / drawingTime;
        Vector3 startPoint = starTransforms[currentIndex].position;
        Vector3 endPoint = starTransforms[(currentIndex + 1) % starTransforms.Count].position;
        lineRenderer.SetPosition(1, Vector3.Lerp(startPoint, endPoint, t));
        if (t >= 1f)
        {
            lineRenderer.SetPosition(1, endPoint); 
            lineRenderer.enabled = false; 
            currentIndex = (currentIndex + 1) % starTransforms.Count; 
        }
    }
}
