using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMuslo : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Engrandecer eng = collision.gameObject.GetComponent<Engrandecer>();
        if (eng != null)
            eng.Activar();
        
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        SpawneableFruits script = GetComponentInParent<SpawneableFruits>();
        if (script != null)
            script.LiberaPosicion(transform.position);
    }
}
