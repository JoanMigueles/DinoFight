using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public int damage;
    private bool hit;
    private Engrandecer eng;

    private void Start()
    {
        hit = true;
        eng = gameObject.GetComponentInParent<Engrandecer>();
    }

    private void OnDisable()
    {
        hit = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var hitbox = collision.gameObject.GetComponent<Damageable>();
        if (hitbox != null && hit)
        {
            int d = damage;
            if (eng.getGrande()) d += 10;
            hitbox.TakeDamage(d, transform.rotation.y == 0);
            hit = false;
        }
    }
}
