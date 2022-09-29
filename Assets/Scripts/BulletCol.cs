using UnityEngine;

public class BulletCol : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 3;
    public float distance;
    public LayerMask whatIsSolid;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid); 
        var effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.5f);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        Destroy(gameObject, 2.7f);
    }
}
