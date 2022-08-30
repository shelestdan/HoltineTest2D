using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public int damage;
    public GameObject destroyEffect;
    public GameObject bloodSplash;
    public LayerMask layerMask;
    
    void Update()
    {
        var transform1 = transform;
        var other = Physics2D.Raycast(transform1.position, transform1.up, distance, layerMask);
        if (other.collider != null)
        {
            if (other.collider.CompareTag($"Enemy"))
            {
                other.collider.GetComponent<Enemy>().TakeDamage(damage);
                Destroy();
            }

            if (other.collider.CompareTag($"Ground"))
            {
                Destroy();
            }
        }
        
        transform1.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void Destroy()
    {
        var position = transform.position;
        Instantiate(destroyEffect, position, Quaternion.identity);
        Instantiate(bloodSplash, position, Quaternion.identity);
        Destroy(gameObject);
    }
}
