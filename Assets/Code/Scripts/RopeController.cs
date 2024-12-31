using UnityEngine;

public class RopeController : MonoBehaviour
{
    private Transform currentCannonball;
    private LineRenderer lineRenderer;
    public bool isAttached { get; private set; }
    public Vector3 anchorPoint;
    private ObjectMomentum momentumScript;
    [SerializeField] private float constantSpeed = 10f;
    [SerializeField] private float maxAttachDistance = 10f;
    private float ropeLength;
    private Camera mainCamera;
    private float currentAngle;
    private float angularVelocity;
    private Vector3 lastPosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            
            if (groundPlane.Raycast(ray, out float distance))
            {
                Vector3 clickPoint = ray.GetPoint(distance);
                
                Transform nearestCannonball = FindNearestCannonball(clickPoint);
                
                if (nearestCannonball != null)
                {
                    currentCannonball = nearestCannonball;
                    anchorPoint = clickPoint;
                    ropeLength = Vector3.Distance(anchorPoint, currentCannonball.position);
                    
                    Rigidbody rb = currentCannonball.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        angularVelocity = constantSpeed / ropeLength;
                        
                        Vector3 radiusVector = (currentCannonball.position - anchorPoint).normalized;
                        Vector3 currentVelocity = rb.linearVelocity;
                        Vector3 cross = Vector3.Cross(radiusVector, currentVelocity.normalized);
                        if (cross.y < 0) angularVelocity *= -1;
                        
                        Vector3 direction = currentCannonball.position - anchorPoint;
                        currentAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                        lastPosition = currentCannonball.position;
                    }

                    isAttached = true;
                    momentumScript = currentCannonball.GetComponent<ObjectMomentum>();
                    if (momentumScript != null)
                    {
                        momentumScript.SetKinematic(true);
                    }
                }
            }
        }

        if (isAttached && currentCannonball != null)
        {
            RotateAroundAnchor();
            UpdateRope();
        }

        if (Input.GetMouseButtonUp(0) && isAttached)
        {
            ReleaseCannonball();
        }
    }

    Transform FindNearestCannonball(Vector3 clickPoint)
    {
        GameObject[] cannonballs = GameObject.FindGameObjectsWithTag("Cannonball");
        Transform nearest = null;
        float nearestDistance = maxAttachDistance;

        foreach (GameObject cannonball in cannonballs)
        {
            float distance = Vector3.Distance(clickPoint, cannonball.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearest = cannonball.transform;
            }
        }

        return nearest;
    }

    void RotateAroundAnchor()
    {
        currentAngle += angularVelocity * Mathf.Rad2Deg * Time.deltaTime;
        
        float x = Mathf.Sin(currentAngle * Mathf.Deg2Rad) * ropeLength;
        float z = Mathf.Cos(currentAngle * Mathf.Deg2Rad) * ropeLength;
        
        Vector3 newPosition = anchorPoint + new Vector3(x, 0, z);
        lastPosition = currentCannonball.position;
        currentCannonball.position = newPosition;
    }

    void ReleaseCannonball()
    {
        if (currentCannonball != null && momentumScript != null)
        {
            momentumScript.SetKinematic(false);
            
            Rigidbody rb = currentCannonball.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 releaseDirection = (currentCannonball.position - lastPosition).normalized;
                rb.linearVelocity = releaseDirection * constantSpeed;
            }
        }

        isAttached = false;
        currentCannonball = null;
        momentumScript = null;
    }

    void UpdateRope()
    {
        if (lineRenderer != null)
        {
            if (isAttached && currentCannonball != null)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.SetPosition(0, currentCannonball.position);
                lineRenderer.SetPosition(1, anchorPoint);
            }
            else
            {
                lineRenderer.positionCount = 0;
            }
        }
    }

    public Vector3 GetCannonballPosition()
    {
        return currentCannonball != null ? currentCannonball.position : Vector3.zero;
    }
}