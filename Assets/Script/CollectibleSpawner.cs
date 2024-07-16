using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject[] collectibles; // Spawnlanacak collectible'ların prefabları
    public Transform playerTransform; // Oyuncunun Transform'u
    public float spawnRadius = 5f; // Collectible'ların spawnlanacağı maksimum mesafe

    public float initialSpawnDelay = 1f; // İlk spawn gecikmesi
    public float spawnInterval = 5f; // Başlangıçtaki spawn aralığı
    public float spawnIntervalIncrement = 0.5f; // Spawn aralığının her seferinde artış miktarı

    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + initialSpawnDelay;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCollectible();
            nextSpawnTime = Time.time + spawnInterval;
            spawnInterval += spawnIntervalIncrement; // Spawn aralığını artır
        }
    }

    void SpawnCollectible()
    {
        int randomIndex = Random.Range(0, collectibles.Length);

        // Oyuncunun pozisyonu etrafında rastgele bir pozisyon belirle
        Vector2 spawnPosition = playerTransform.position + (Vector3)Random.insideUnitCircle * spawnRadius;

        Instantiate(collectibles[randomIndex], spawnPosition, Quaternion.identity);
    }
}