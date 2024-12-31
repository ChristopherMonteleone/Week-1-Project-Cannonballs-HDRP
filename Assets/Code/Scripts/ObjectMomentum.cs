using UnityEngine;

public class ObjectMomentum : MonoBehaviour
{
    [SerializeField] private float constantSpeed = 50f; // Should match RopeController's speed
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Set initial velocity with constant speed
            rb.linearVelocity = -Vector3.forward * constantSpeed;
        }
    }

    public void SetKinematic(bool isKinematic)
    {
        if (rb != null)
        {
            rb.isKinematic = isKinematic;
        }
    }
}