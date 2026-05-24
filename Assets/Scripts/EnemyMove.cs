using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Rigidbody2D rigid;
    public float nextMove;
    public Transform Player;
    public float moveSpeed = 2.0f;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {
        if (Player.position.x > transform.position.x)
        {
            nextMove = 1;
        }
        else
        {
            nextMove = -1;
        }

        //Animation
        if (Mathf.Abs(rigid.linearVelocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);
    }

    void FixedUpdate()
    {
        //Move
     rigid.linearVelocity = new Vector2(nextMove * moveSpeed, rigid.linearVelocity.y);


    }
}

 

    //재귀함수: 자신을 스스로 호출하는 함수
    //딜레이 없이 사용하는 것은 아주 위험하다
    //그러므로 주어진 시간 지나고 지정된 함수를 실행하는 Invoke 사용
   
