using UnityEngine;

public class AgainMove : MonoBehaviour
{
    public int hp = 100;
    public int damage = 10;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public float nextMove;
    public Transform Player;
    public float moveSpeed = 2.0f;
    public float attackRange = 2.5f;
    public float attackTime = 0.7f;
    public float attackDelay = 1.0f;
    Animator anim;
    bool isAttacking;
    float attackTimer;
    float nextAttackTime;

    void Awake()
    {
        hp = 100;
        damage = 10;
        attackRange = 2.5f;
        attackTime = 0.7f;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Player == null)
        {
            PlayerMove playerMove = FindAnyObjectByType<PlayerMove>();

            if (playerMove != null)
                Player = playerMove.transform;
        }

        if (Player == null || rigid == null || spriteRenderer == null || anim == null)
            return;

        float distance = Mathf.Abs(Player.position.x - transform.position.x);

        if (Player.position.x > transform.position.x)
        {
            nextMove = 1;
        }
        else
        {
            nextMove = -1;
        }

        spriteRenderer.flipX = nextMove != 1;

        if (isAttacking)
        {
            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0)
            {
                isAttacking = false;
                anim.SetBool("isAttacking", false);
            }

            return;
        }

        if (distance <= attackRange && Time.time >= nextAttackTime)
        {
            StartAttack();
            return;
        }

        anim.SetBool("isWalking", Mathf.Abs(rigid.linearVelocity.x) >= 0.3f);
    }

    void FixedUpdate()
    {
        if (rigid == null)
            return;

        if (isAttacking)
        {
            rigid.linearVelocity = new Vector2(0, rigid.linearVelocity.y);
            return;
        }

        rigid.linearVelocity = new Vector2(nextMove * moveSpeed, rigid.linearVelocity.y);
    }

    void StartAttack()
    {
        isAttacking = true;
        attackTimer = attackTime;
        nextAttackTime = Time.time + attackDelay;

        rigid.linearVelocity = new Vector2(0, rigid.linearVelocity.y);
        anim.SetBool("isWalking", false);
        anim.SetBool("isAttacking", true);

        PlayerMove playerMove = Player.GetComponent<PlayerMove>();

        if (playerMove != null)
            playerMove.SetDamage(damage);
    }

    public void SetDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            hp = 0;
            Destroy(gameObject);
        }
    }
}
