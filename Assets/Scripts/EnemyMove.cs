using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public int hp = 100;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    public float nextMove;
    public Transform Player;
    public float moveSpeed = 2.0f;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        if (Player == null || rigid == null || spriteRenderer == null || anim == null)
            return;

        if (Player.position.x > transform.position.x)
        {
            nextMove = 1;
        }
        else
        {
            nextMove = -1;
        }

        spriteRenderer.flipX = nextMove == 1;

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

        //Move
        rigid.linearVelocity = new Vector2(nextMove * moveSpeed, rigid.linearVelocity.y);


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

