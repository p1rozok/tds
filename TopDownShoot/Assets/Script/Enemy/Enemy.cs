
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRange = 5f;
    public float attackRange = 1f;
    public int health = 10;
    public int attackDamage = 10;
    public float attackCooldown = 2f;
    public GameObject dropItem;
    public int scoreValue = 10;

    private Transform player;
    private Rigidbody2D rb;
    private float lastAttackTime;
    private Animator animator;
    private bool facingRight = true;
    private GameScoreManager gameScoreManager;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameScoreManager = FindObjectOfType<GameScoreManager>();

        if (player == null)
        {
            Debug.LogError("Player �� ������!");
        }

        if (rb == null)
        {
            Debug.LogError("��� ���������� Rigidbody2D �� ������� " + gameObject.name);
        }

        if (gameScoreManager == null)
        {
            Debug.LogError("GameScoreManager �� ������ � �����!");
        }

        lastAttackTime = Time.time - attackCooldown;
    }

    void Update()
    {
        if (player == null || rb == null) return;

        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player == null)
        {
            Debug.LogError("Player �� ������!");
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }

        if ((direction.x < 0 && facingRight) || (direction.x > 0 && !facingRight))
        {
            Flip();
        }

        animator.SetBool("isRunning", direction.magnitude > 0);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void AttackPlayer()
    {
        if (player != null)
        {
            PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                animator.SetTrigger("Attack");
                Debug.Log("����� ������!");
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"���� ������� {damage} �����, �������� ��������: {health}");

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("���� ����!");

        if (dropItem != null)
        {
            Instantiate(dropItem, transform.position, Quaternion.identity);
        }

        if (gameScoreManager != null)
        {
            Debug.Log($"���������� �����: {scoreValue}");
            gameScoreManager.AddScore(scoreValue);
        }
        else
        {
            Debug.LogError("GameScoreManager �� ������ ��� ������ �����!");
        }

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(attackDamage);
                animator.SetTrigger("Attack");
                Debug.Log("����� ������ ��� ������������!");
            }
        }
    }
}
