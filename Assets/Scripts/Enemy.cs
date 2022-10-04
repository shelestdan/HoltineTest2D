using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 30;
    public float speed;
    public GameObject deathEffect;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rbEnemy;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        isInChaseRange = Physics2D.OverlapCircle(transform.position, checkRadius, whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position, attackRadius, whatIsPlayer);

        dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isInChaseRange && !isInAttackRange)
        {
            MoveCharacter(movement);
        }

        if (isInAttackRange)
        {
            rbEnemy.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        rbEnemy.MovePosition((Vector2)transform.position + (dir * (speed * Time.deltaTime)));
    }
    

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
