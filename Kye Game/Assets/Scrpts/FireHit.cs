using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHit : MonoBehaviour
{
    public int damage;
    public float tiempoEspera;

    private bool hit;

    private void Start()
    {
        hit = true;
    }

    private void QuemarActivado()
    {
        hit = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var hitbox = collision.gameObject.GetComponent<Damageable>();
        if (hitbox != null && hit)
        {
            hitbox.TakeDamage(damage, transform.rotation.y == 0);
            hit = false;
            Invoke("QuemarActivado", tiempoEspera);
        }
    }
}
