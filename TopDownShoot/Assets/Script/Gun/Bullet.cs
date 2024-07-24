using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 2;
    public float lifetime = 2f;
    public LayerMask whatIsSolid; // Слой, который пуля будет считать твердым
    public GameObject destroyEffect;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("DestroyBullet", lifetime);
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Проверка на столкновение с твердым объектом
        if (((1 << hitInfo.gameObject.layer) & whatIsSolid) != 0)
        {
            if (hitInfo.CompareTag("Enemy"))
            {
                Enemy enemy = hitInfo.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        if (destroyEffect != null)
        {
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
