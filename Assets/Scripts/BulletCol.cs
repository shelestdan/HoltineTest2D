using UnityEngine;

public class BulletCol : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 3;
    
    public void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        hitInfo.GetComponent<Collider2D>();
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 1.5f);
    }
    
    private void Update()
    {
        Destroy(gameObject, 2.7f);
    }
}