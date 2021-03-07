using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UsageTest : MonoBehaviour
{
    public static UsageTest Instance;

    public GameObject cannonballPrefab;

    public int preloadCount = 500;
    public int spawned = 0;
    public float spawnRadius = 5f;
    public int spawnPoints = 8;
    public float initialSpawnVelocity = 3f;
    public float lastSpawnAngle = 0f;

    public float countdown = 1f;
    public float orig_countdown;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        Physics.gravity = new Vector3(0f, -1f, 0f); // Set gravity to be very low for testing.
        SimplePool.Preload(cannonballPrefab, preloadCount); // Start out with a preset number of instances.
    }


    private void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            // Find a new position
            Vector3 newPos = Quaternion.AngleAxis(lastSpawnAngle, Vector3.up) * Vector3.forward * spawnRadius;
            lastSpawnAngle += 360 / spawnPoints;

            GameObject go = SimplePool.Spawn(cannonballPrefab, newPos, Quaternion.identity);
            spawned++;

            go.GetComponent<Rigidbody>().velocity = (newPos.normalized + Vector3.up) * initialSpawnVelocity;
            go.transform.parent = transform;
            countdown = orig_countdown;
        }
    }



    public IEnumerator Remove(GameObject go, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        SimplePool.Despawn(go, this.transform);
    }

    public void Remove(GameObject go)
    {
        SimplePool.Despawn(go, this.transform);
    }


}
