
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    public GameObject[] bonusPrefabs; // ������ �������� �������
    public float spawnInterval = 10f; // �������� ������ �������

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
        // ����� ���������� ������
        int bonusIndex = Random.Range(0, bonusPrefabs.Length);
        GameObject bonusPrefab = bonusPrefabs[bonusIndex];

        // ����� ��������� ������� � ���� ��������� ������
        Vector2 spawnPosition = GetRandomSpawnPosition();
        Instantiate(bonusPrefab, spawnPosition, Quaternion.identity);
    }

    Vector2 GetRandomSpawnPosition()
    {
        // ��������� ������ ������
        Vector3 cameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // ��������� ��������� ������� � �������� ������
        float x = Random.Range(cameraBottomLeft.x, cameraTopRight.x);
        float y = Random.Range(cameraBottomLeft.y, cameraTopRight.y);

        return new Vector2(x, y);
    }
}
