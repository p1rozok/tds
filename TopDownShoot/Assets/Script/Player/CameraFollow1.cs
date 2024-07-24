using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ����, �� ������� ����� ��������� ������ (��������)
    public float smoothing = 5f; // �������� ����������� �������� ������
    public Vector3 offset; // �������� ������ ������������ ����
    public Vector2 minBounds; // ����������� ���������� ������
    public Vector2 maxBounds; // ������������ ���������� ������

    void Start()
    {
        // ������������ ��������� �������� �� ����
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // �������� ������� ������
        Vector3 targetCamPos = target.position + offset;

        // ������������ ��������� ������ � �������� ������
        targetCamPos.x = Mathf.Clamp(targetCamPos.x, minBounds.x, maxBounds.x);
        targetCamPos.y = Mathf.Clamp(targetCamPos.y, minBounds.y, maxBounds.y);

        // ������� ����������� ������ � �������� �������
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
