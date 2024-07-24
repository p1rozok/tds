
using UnityEngine;

public class ZoneSpawner : MonoBehaviour
{
    public GameObject slowZonePrefab;
    public GameObject deathZonePrefab;

    public int slowZoneCount = 3;
    public int deathZoneCount = 2;

    private float mapWidth = 40f;
    private float mapHeight = 30f;

    void Start()
    {
        SpawnZones(slowZonePrefab, slowZoneCount, 3f);
        SpawnZones(deathZonePrefab, deathZoneCount, 1f);
    }

    void SpawnZones(GameObject zonePrefab, int count, float radius)
    {
        for (int i = 0; i < count; i++)
        {
            Vector3 position;
            bool validPosition;
            int attempts = 0;

            do
            {
                position = new Vector3(Random.Range(-mapWidth / 2 + radius, mapWidth / 2 - radius),
                                       Random.Range(-mapHeight / 2 + radius, mapHeight / 2 - radius), 0);

                validPosition = true;

                Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
                foreach (var collider in colliders)
                {
                    if (collider.CompareTag("Zone"))
                    {
                        validPosition = false;
                        break;
                    }
                }

                attempts++;
                if (attempts > 100) break; // ѕредотвращение бесконечного цикла

            } while (!validPosition);

            if (validPosition)
            {
                Instantiate(zonePrefab, position, Quaternion.identity);
            }
        }
    }
}
