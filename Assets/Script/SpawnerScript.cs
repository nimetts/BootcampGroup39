using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Oluşturulacak obje
    public int numberOfObjects; // Kaç obje oluşturulacak
    public Vector2 spawnAreaMin; // Spawn alanının minimum koordinatları
    public Vector2 spawnAreaMax; // Spawn alanının maksimum koordinatları

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}