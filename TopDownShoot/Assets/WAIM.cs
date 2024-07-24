
using UnityEngine;

public class WeaponRotationController : MonoBehaviour
{
    public float offset = 0f; // Смещение угла поворота оружия
    public Joystick joystick; // Джойстик для управления на мобильных устройствах
    public PlayerController player; // Ссылка на скрипт игрока

    private bool facingRight = true; // Проверка направления, в котором смотрит оружие

    void Start()
    {
        if (player == null)
        {
            player = GetComponentInParent<PlayerController>();
            if (player == null)
            {
                Debug.LogError("Player не назначен и не найден в родительских объектах.");
            }
        }

        if (joystick == null)
        {
            Debug.LogError("Joystick не назначен в инспекторе.");
        }

        // Отключаем джойстик, если управление осуществляется на ПК
        if (player != null && player.controlType == PlayerController.ControlType.PC && joystick != null)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 difference;

        // Получаем разницу позиции в зависимости от способа управления
        if (player.controlType == PlayerController.ControlType.PC)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.z = 0; // Убираем компонент z
        }
        else
        {
            difference = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        }

        if (difference != Vector3.zero)
        {
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            // Проверка направления и вызов Flip при необходимости
            if ((difference.x > 0 && !facingRight) || (difference.x < 0 && facingRight))
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.y *= -1; // Переворот по оси Y
        transform.localScale = scaler;

        // Переворачиваем игрока, если необходимо
        if (player != null)
        {
            player.Flip();
        }
    }
}
