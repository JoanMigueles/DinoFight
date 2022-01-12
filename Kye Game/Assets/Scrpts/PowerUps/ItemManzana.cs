using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManzana : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Damageable heal = collision.gameObject.GetComponent<Damageable>();

        if (heal != null)
            heal.Heal(50);

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SpawneableFruits script = GetComponentInParent<SpawneableFruits>();
        if(script != null)
            script.LiberaPosicion(transform.position);
    }
}
