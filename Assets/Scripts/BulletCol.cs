using UnityEngine;

public class BulletCol : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 3;
    public LayerMask whatIsSolid;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var transform1 = transform;
        var position = transform1.position;
        var hitInfo = Physics2D.Raycast(position, transform1.up, whatIsSolid); 
        var effect = Instantiate(hitEffect, position, Quaternion.identity);
        Destroy(effect, 1.5f);
        if (hitInfo.collider == null) return;
        if (hitInfo.collider.CompareTag("Enemy"))
        {
            hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void Update()
    {
      Destroy(gameObject, 2.7f);
    }
}
