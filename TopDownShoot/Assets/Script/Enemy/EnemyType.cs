using UnityEngine;

[System.Serializable]
public struct EnemyType
{
    public GameObject enemyPrefab; // Префаб врага
    public float spawnChance; // Шанс спавна в процентах
    public float speed; // Скорость врага
    public int health; // Здоровье врага
    public int pointsForKill; // Очки за убийство
}
