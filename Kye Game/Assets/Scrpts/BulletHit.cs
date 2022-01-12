using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public int damage;
    private Player2 pl2;

    private void Start()
    {
        pl2 = gameObject.GetComponentInParent<Player2>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if ((collision.gameObject.GetComponent<Player2>() != null && pl2 == null) ||
            (collision.gameObject.GetComponent<Player2>() == null && pl2 != null && collision.gameObject.GetComponent<PlayerController>() != null))
        {
            int d = damage;
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            var hitbox = collision.gameObject.GetComponent<Damageable>();
            hitbox.TakeDamage(d, rb.velocity.x > 0);
            Destroy(gameObject);
        }
    }
}
