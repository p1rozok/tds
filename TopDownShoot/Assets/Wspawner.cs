

using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public GameObject pistolPrefab;
    public GameObject riflePrefab;
    public GameObject shotgunPrefab;
    public GameObject grenadeLauncherPrefab;

    public float spawnInterval = 10f; // Интервал спавна оружия в секундах
    private float spawnTimer;

    private PlayerController player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        if (player == null)
        {
            Debug.LogError("Player не найден!");
        }

        spawnTimer = spawnInterval; // Устанавливаем таймер на интервал спавна
    }

    void Update()
    {
        if (spawnTimer <= 0f)
        {
            SpawnWeapon();
            spawnTimer = spawnInterval; // Сброс таймера
        }
        else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    void SpawnWeapon()
    {
        GameObject weaponPrefab = GetRandomWeaponPrefab();
        if (weaponPrefab != null)
        {
            Vector3 spawnPosition = GetRandomSpawnPosition();
            Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);
        }
    }

    GameObject GetRandomWeaponPrefab()
    {
        GameObject[] weaponPrefabs = { pistolPrefab, riflePrefab, shotgunPrefab, grenadeLauncherPrefab };
        PlayerController.Weapon currentPlayerWeapon = player != null ? player.currentWeapon : PlayerController.Weapon.Pistol;

        // Фильтрация текущего оружия
        GameObject[] availableWeapons = System.Array.FindAll(weaponPrefabs, weaponPrefab =>
        {
            if (weaponPrefab == null)
            {
                Debug.LogError("Один из префабов оружия не назначен.");
                return false;
            }

            WeaponPickup weaponPickup = weaponPrefab.GetComponent<WeaponPickup>();
            if (weaponPickup == null)
            {
                Debug.LogError("WeaponPickup компонент не найден на " + weaponPrefab.name);
                return false;
            }

            return weaponPickup.weaponType != currentPlayerWeapon;
        });

        if (availableWeapons.Length == 0)
        {
            Debug.LogError("Нет доступных для спавна оружий, отличных от текущего оружия игрока.");
            return null;
        }

        // Выбор случайного оружия из доступных
        int randomIndex = Random.Range(0, availableWeapons.Length);
        return availableWeapons[randomIndex];
    }

    Vector3 GetRandomSpawnPosition()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Основная камера не найдена!");
            return Vector3.zero;
        }

        // Получаем границы видимости камеры
        Vector3 cameraPos = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Генерируем случайную позицию в пределах видимости камеры
        float randomX = Random.Range(cameraPos.x - cameraWidth / 2f, cameraPos.x + cameraWidth / 2f);
        float randomY = Random.Range(cameraPos.y - cameraHeight / 2f, cameraPos.y + cameraHeight / 2f);

        return new Vector3(randomX, randomY, 0);
    }
}
