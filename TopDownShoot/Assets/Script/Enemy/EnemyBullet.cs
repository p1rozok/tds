using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 2;
    public float lifetime = 2f;
    public LayerMask whatIsSolid;
    public GameObject destroyEffect;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Invoke("DestroyBullet", lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (((1 << hitInfo.gameObject.layer) & whatIsSolid) != 0)
        {
            if (hitInfo.CompareTag("Player"))
            {
                hitInfo.GetComponent<PlayerHealth>().TakeDamage(damage);
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
