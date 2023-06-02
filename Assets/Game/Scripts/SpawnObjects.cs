using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int spawnCount = 10;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f) + transform.position.x;
        float randomZ = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f) + transform.position.z;
        return new Vector3(randomX, transform.position.y, randomZ);
    }
}

