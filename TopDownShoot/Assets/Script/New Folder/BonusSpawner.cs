
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject[] bonusPrefabs; // Массив префабов бонусов
    public float spawnInterval = 10f; // Интервал спавна бонусов

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnBonuses());
    }

    IEnumerator SpawnBonuses()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnBonus();
        }
    }

    void SpawnBonus()
    {
        // Выбор случайного бонуса
        int bonusIndex = Random.Range(0, bonusPrefabs.Length);
        GameObject bonusPrefab = bonusPrefabs[bonusIndex];

        // Выбор случайной позиции в зоне видимости камеры
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(bonusPrefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomSpawnPosition()
    {
        // Получение границ камеры
        Vector3 cameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Генерация случайной позиции в границах камеры
        float x = Random.Range(cameraBottomLeft.x, cameraTopRight.x);
        float y = Random.Range(cameraBottomLeft.y, cameraTopRight.y);

        return new Vector2(x, y);
    }
}
