using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject destroyEffect;
    public GameObject bloodSplash;
    
    void Update()
    {
        if (health <= 0)
        {
            var position = transform.position;
            Instantiate(destroyEffect, position, Quaternion.identity);
            Instantiate(bloodSplash, position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
