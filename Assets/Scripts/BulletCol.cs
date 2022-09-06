using System;
using UnityEngine;

public class BulletCol : MonoBehaviour
{

  public GameObject hitEffect;
  private void OnCollisionEnter2D(Collision2D collision)
  {
      GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
      Destroy(effect, 1.5f);
      Destroy(gameObject);
  }
}
