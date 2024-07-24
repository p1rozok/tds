
using UnityEngine;

public class WeaponRotationController : MonoBehaviour
{
    public float offset = 0f; // �������� ���� �������� ������
    public Joystick joystick; // �������� ��� ���������� �� ��������� �����������
    public PlayerController player; // ������ �� ������ ������

    private bool facingRight = true; // �������� �����������, � ������� ������� ������

    void Start()
    {
        if (player == null)
        {
            player = GetComponentInParent<PlayerController>();
            if (player == null)
            {
                Debug.LogError("Player �� �������� � �� ������ � ������������ ��������.");
            }
        }

        if (joystick == null)
        {
            Debug.LogError("Joystick �� �������� � ����������.");
        }

        // ��������� ��������, ���� ���������� �������������� �� ��
        if (player != null && player.controlType == PlayerController.ControlType.PC && joystick != null)
        {
            joystick.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (player == null) return;

        Vector3 difference;

        // �������� ������� ������� � ����������� �� ������� ����������
        if (player.controlType == PlayerController.ControlType.PC)
        {
            difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.z = 0; // ������� ��������� z
        }
        else
        {
            difference = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
        }

        if (difference != Vector3.zero)
        {
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

            // �������� ����������� � ����� Flip ��� �������������
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
        scaler.y *= -1; // ��������� �� ��� Y
        transform.localScale = scaler;

        // �������������� ������, ���� ����������
        if (player != null)
        {
            player.Flip();
        }
    }
}
