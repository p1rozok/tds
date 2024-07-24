using UnityEngine;

[System.Serializable]
public struct EnemyType
{
    public GameObject enemyPrefab; // ������ �����
    public float spawnChance; // ���� ������ � ���������
    public float speed; // �������� �����
    public int health; // �������� �����
    public int pointsForKill; // ���� �� ��������
}
