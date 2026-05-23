using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        
    }
}
