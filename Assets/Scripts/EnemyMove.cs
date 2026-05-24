using UnityEngine;

public class EnemyMove : MonoBehaviour
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
        damage = 10;
        attackRange = 2.5f;
        attackTime = 0.7f;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
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

        spriteRenderer.flipX = nextMove == 1;

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

        //Animation
        if (Mathf.Abs(rigid.linearVelocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
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

        //Move
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
        anim.CrossFade("Danso_Attack", 0f, 0, 0f);

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



//재귀함수: 자신을 스스로 호출하는 함수
//딜레이 없이 사용하는 것은 아주 위험하다
//그러므로 주어진 시간 지나고 지정된 함수를 실행하는 Invoke 사용

