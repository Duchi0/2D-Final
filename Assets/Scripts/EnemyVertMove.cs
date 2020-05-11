using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertMove : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();
    }
    private void Move()
    {
        enemyRb.velocity = new Vector2(5, 0);
        enemyRb.velocity = new Vector2(-5, 0);
    }
}
