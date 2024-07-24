using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Цель, за которой будет следовать камера (персонаж)
    public float smoothing = 5f; // Скорость сглаживания движения камеры
    public Vector3 offset; // Смещение камеры относительно цели
    public Vector2 minBounds; // Минимальные координаты камеры
    public Vector2 maxBounds; // Максимальные координаты камеры

    void Start()
    {
        // Рассчитываем начальное смещение от цели
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // Желаемая позиция камеры
        Vector3 targetCamPos = target.position + offset;

        // Ограничиваем положение камеры в пределах границ
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minBounds.x, maxBounds.x);
        targetCamPos.y = Mathf.Clamp(targetCamPos.y, minBounds.y, maxBounds.y);

        // Плавное перемещение камеры к желаемой позиции
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
