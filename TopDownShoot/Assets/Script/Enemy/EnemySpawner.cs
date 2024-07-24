using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDefinition
{
    public GameObject enemyPrefab;
    public float spawnChance;
    public int scoreValue; // Очки за уничтожение врага
}
public class EnemySpawner : MonoBehaviour
{
    public EnemyDefinition[] enemyDefinitions;
    public float initialSpawnInterval = 2f;
    public float spawnIntervalDecrease = 0.1f;
    public float minimumSpawnInterval = 0.5f;
    private float currentSpawnInterval;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(ReduceSpawnInterval());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnInterval);
            SpawnEnemy();
        }
    }

    IEnumerator ReduceSpawnInterval()
    {
        while (currentSpawnInterval > minimumSpawnInterval)
        {
            yield return new WaitForSeconds(10f);
            currentSpawnInterval -= spawnIntervalDecrease;
        }
    }

    void SpawnEnemy()
    {
        EnemyDefinition enemyDef = GetRandomEnemyDefinition();

        if (enemyDef == null) return;

        Vector3 cameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        Vector3 spawnPosition = GetRandomSpawnPosition(cameraBottomLeft, cameraTopRight);
        GameObject enemyInstance = Instantiate(enemyDef.enemyPrefab, spawnPosition, Quaternion.identity);

        // Передача очков за уничтожение врага
        Enemy enemyScript = enemyInstance.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.scoreValue = enemyDef.scoreValue;
        }
    }

    EnemyDefinition GetRandomEnemyDefinition()
    {
        float total = 0;
        foreach (EnemyDefinition enemy in enemyDefinitions)
        {
            total += enemy.spawnChance;
        }

        float randomPoint = Random.value * total;

        foreach (EnemyDefinition enemy in enemyDefinitions)
        {
            if (randomPoint < enemy.spawnChance)
            {
                return enemy;
            }
            else
            {
                randomPoint -= enemy.spawnChance;
            }
        }
        return null;
    }

    Vector3 GetRandomSpawnPosition(Vector3 cameraBottomLeft, Vector3 cameraTopRight)
    {
        float x, y;
        float spawnMargin = 5f;

        if (Random.value < 0.5f)
        {
            x = Random.value < 0.5f ? cameraBottomLeft.x - spawnMargin : cameraTopRight.x + spawnMargin;
            y = Random.Range(cameraBottomLeft.y - spawnMargin, cameraTopRight.y + spawnMargin);
        }
        else
        {
            x = Random.Range(cameraBottomLeft.x - spawnMargin, cameraTopRight.x + spawnMargin);
            y = Random.value < 0.5f ? cameraBottomLeft.y - spawnMargin : cameraTopRight.y + spawnMargin;
        }

        return new Vector3(x, y, 0);
    }
}
