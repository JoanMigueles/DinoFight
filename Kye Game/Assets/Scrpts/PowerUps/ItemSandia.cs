using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSandia : MonoBehaviour
{
    public int numBalas;

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerCombat pl = collision.gameObject.GetComponent<PlayerCombat>();

        if (pl != null)
        {
            pl.ActivarBalas(numBalas);
        }

        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        SpawneableFruits script = GetComponentInParent<SpawneableFruits>();
        if (script != null)
            script.LiberaPosicion(transform.position);
    }
}
