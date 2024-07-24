using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public enum ControlType { PC, Android }
    public ControlType controlType;
    public enum Weapon { Pistol, Rifle, Shotgun, GrenadeLauncher }
    public Weapon currentWeapon;

    public float speed = 5f; // Обычная скорость игрока
    private float originalSpeed;
    private bool isInvincible = false;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator animator;
    private bool facingRight = true;
    public Joystick joystick;

    public GameObject pistolModel;
    public GameObject rifleModel;
    public GameObject shotgunModel;
    public GameObject grenadeLauncherModel;

    private GameObject currentWeaponModel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalSpeed = speed;

        rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        if (controlType == ControlType.PC)
        {
            joystick.gameObject.SetActive(false); // Скрываем джойстик
        }

        EquipWeapon(currentWeapon); // Экипировать начальное оружие
    }

    void Update()
    {
        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        else if (controlType == ControlType.Android)
        {
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        moveVelocity = moveInput.normalized * speed;

        // Управление анимацией
        if (animator != null)
        {
            bool isRunning = moveInput != Vector2.zero;
            animator.SetBool("isRunning", isRunning);

            // Проверка направления движения и вызов Flip при необходимости
            if (moveInput.x > 0 && !facingRight)
            {
                Flip();
            }
            else if (moveInput.x < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void SetWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        Debug.Log("Current weapon set to: " + weapon);
        EquipWeapon(weapon);
    }

    void EquipWeapon(Weapon weapon)
    {
        // Удаляем старую модель оружия, если она есть
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        // Выбираем модель оружия в зависимости от текущего оружия
        switch (weapon)
        {
            case Weapon.Pistol:
                currentWeaponModel = Instantiate(pistolModel, transform);
                break;
            case Weapon.Rifle:
                currentWeaponModel = Instantiate(rifleModel, transform);
                break;
            case Weapon.Shotgun:
                currentWeaponModel = Instantiate(shotgunModel, transform);
                break;
            case Weapon.GrenadeLauncher:
                currentWeaponModel = Instantiate(grenadeLauncherModel, transform);
                break;
        }

        // Уведомляем GunController об изменении оружия
        GunController gunController = GetComponentInChildren<GunController>();
        if (gunController != null)
        {
            gunController.SetWeapon(weapon);
        }
    }

    public void PickupWeapon(GameObject weaponPrefab)
    {
        if (currentWeaponModel != null)
        {
            Destroy(currentWeaponModel);
        }

        currentWeaponModel = Instantiate(weaponPrefab, transform.position, transform.rotation, transform);
        Debug.Log("Weapon picked up: " + weaponPrefab.name);
    }

    public IEnumerator SpeedBoost(float duration)
    {
        speed *= 1.5f;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }

    public IEnumerator Invincibility(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        // Логика получения урона
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speed = originalSpeed * multiplier;
    }
}
