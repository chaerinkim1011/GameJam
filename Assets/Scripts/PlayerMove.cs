using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int hp = 200;
    public int mp = 100;
    public float maxSpeed;
    public int damage = 10;
    public float attackRange = 1.5f;
    public Vector2 attackBoxSize = new Vector2(3f, 1.5f);
    public float minX = -8.5f;
    public float maxX = 48.8f;
    public string badEndingSceneName = "BadEnding";

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;
    bool isAttacking;
    float attackTimer;

    const float attackTime = 0.08f;

    void Awake()
    {
        hp = 200;
        attackRange = 3f;
        attackBoxSize = new Vector2(3f, 1.5f);
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAttacking = true;
            attackTimer = attackTime;
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", true);
            anim.Play("Player_Attack", 0, 0f);

            AttackEnemy();
        }

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                isAttacking = false;
                anim.SetBool("isAttacking", false);
            }
        }

        if (Input.GetButtonUp("Horizontal"))
            rigid.linearVelocity = new Vector2(rigid.linearVelocity.normalized.x * 0.5f, rigid.linearVelocity.y);

        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (!isAttacking)
            anim.SetBool("isRunning", Mathf.Abs(rigid.linearVelocity.x) >= 0.3f);
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.linearVelocity.x > maxSpeed)
            rigid.linearVelocity = new Vector2(maxSpeed, rigid.linearVelocity.y);

        if (rigid.linearVelocity.x < -maxSpeed)
            rigid.linearVelocity = new Vector2(-maxSpeed, rigid.linearVelocity.y);

        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    public void SetDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            SceneManager.LoadScene(badEndingSceneName);
        }
    }

    void AttackEnemy()
    {
        EnemyMove target = null;
        float closestDistance = attackRange;
        float direction = spriteRenderer.flipX ? -1f : 1f;
        Vector2 attackCenter = (Vector2)transform.position + Vector2.right * direction * (attackRange * 0.5f);
        Collider2D[] hits = Physics2D.OverlapBoxAll(attackCenter, attackBoxSize, 0f);

        foreach (Collider2D hit in hits)
        {
            EnemyMove foundEnemy = hit.GetComponent<EnemyMove>();

            if (foundEnemy == null)
                continue;

            float distance = Vector2.Distance(transform.position, foundEnemy.transform.position);

            if (distance > closestDistance)
                continue;

            closestDistance = distance;
            target = foundEnemy;
        }

        if (target != null)
            target.SetDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        float direction = 1f;

        if (spriteRenderer != null)
            direction = spriteRenderer.flipX ? -1f : 1f;

        Vector2 attackCenter = (Vector2)transform.position + Vector2.right * direction * (attackRange * 0.5f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(attackCenter, attackBoxSize);
    }
}
