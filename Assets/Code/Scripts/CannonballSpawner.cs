using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cannonballPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float initialSpeed = 10f;
    private float nextSpawnTime;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCannonball();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCannonball()
    {
        GameObject newCannonball = Instantiate(cannonballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = newCannonball.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = -Vector3.forward * initialSpeed;
        }
    }
}