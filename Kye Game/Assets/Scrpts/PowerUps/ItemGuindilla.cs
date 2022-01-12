using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGuindilla : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Fire fuego = collision.gameObject.GetComponent<Fire>();

        if (fuego != null)
        {
            fuego.ActivarFuego();
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
