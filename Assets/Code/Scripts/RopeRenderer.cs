using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public RopeController ropeController;

    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        if (lineRenderer != null)
        {
            lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
            lineRenderer.startColor = Color.black;
            lineRenderer.endColor = Color.black;
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.1f;
        }
    }

    void Update()
    {
        if (ropeController != null && ropeController.isAttached)
        {
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, ropeController.GetCannonballPosition());
            lineRenderer.SetPosition(1, ropeController.anchorPoint);
        }
        else
        {
            lineRenderer.positionCount = 0;
        }
    }
}