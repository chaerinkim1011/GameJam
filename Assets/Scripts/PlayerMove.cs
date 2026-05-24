using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public int hp = 200;
    public int mp = 100;
    public float maxSpeed;
    public int damage = 10;
    public float attackRange = 1.5f;
    public float minX = -8.5f;
    public float maxX = 48.8f;
    public string badEndingSceneName = "BadEnding";

    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    Animator anim;
    EnemyMove enemy;
    bool isAttacking;
    float attackTimer;

    const float attackTime = 0.08f;

    void Awake()
    {
        hp = 200;
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
        EnemyMove target = enemy;

        if (target == null)
        {
            float direction = spriteRenderer.flipX ? -1f : 1f;
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, attackRange);

            foreach (Collider2D hit in hits)
            {
                EnemyMove foundEnemy = hit.GetComponent<EnemyMove>();

                if (foundEnemy == null)
                    continue;

                float enemyDirection = Mathf.Sign(foundEnemy.transform.position.x - transform.position.x);

                if (enemyDirection == direction)
                {
                    target = foundEnemy;
                    break;
                }
            }
        }

        if (target != null)
            target.SetDamage(damage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        enemy = collision.gameObject.GetComponent<EnemyMove>();
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMove>() == enemy)
            enemy = null;
    }
}
