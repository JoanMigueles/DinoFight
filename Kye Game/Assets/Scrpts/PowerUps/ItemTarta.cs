using UnityEngine;

public class ItemTarta : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        Damageable heal = collision.gameObject.GetComponent<Damageable>();
        Explosion expl = collision.gameObject.GetComponent<Explosion>();

        
        if (heal != null)
            heal.Heal(20);

        if (expl != null)
        {
            expl.ActivarExplosion();
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
