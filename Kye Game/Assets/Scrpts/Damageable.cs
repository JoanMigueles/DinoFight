using UnityEngine;
using UnityEngine.UI;

public class Damageable : MonoBehaviour
{
    public int vida;
    public RectTransform barra;
    public Text textoPuntos;

    private Rigidbody2D rb;
    private PlayerController player;
    private SpriteRenderer sprite;
    private Animator anim;
    private float originalSize;

    private uint points;
    private bool invencible;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
        sprite = GetComponent<SpriteRenderer>();
        originalSize = barra.rect.width;
        points = 0;
        invencible = false;
    }

    public void TakeDamage(int damage, bool derecha)
    {
        if (!invencible)
        {
            vida -= damage;


            barra.sizeDelta = new Vector2(originalSize * vida / 100, barra.rect.height);
            if (vida <= 0) AddPointAndRespawn();
            else
            {
                if (derecha)
                    rb.velocity = new Vector2(3, 3);
                else
                    rb.velocity = new Vector2(-3, 3);

                anim.SetTrigger("dañado");
            }
        }
    }

    public void Heal(int healing)
    {
        vida += healing;
        if (vida > 100)
        {
            vida = 100;
        }
        barra.sizeDelta = new Vector2(originalSize * vida / 100, barra.rect.height);
    }

    public void AddPointAndRespawn()
    {
        points++;
        textoPuntos.text = points.ToString();
        player.OnDeath();
        Heal(100 - vida);
        invencible = true;
        Invoke("DesactivarInvencible", 3f);
        Invoke("Transparente", 0.2f);
    }

    private void Transparente()
    {
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f);
        Invoke("Opaco", 0.2f);
    }

    private void Opaco()
    {
        sprite.color = new Vector4(sprite.color.r, sprite.color.g, sprite.color.b, 1f);
        if (invencible)
            Invoke("Transparente", 0.2f);
    }

    private void DesactivarInvencible()
    {
        invencible = false;
    }

    public void ResetPoints()
    {
        points = 0;
        textoPuntos.text = points.ToString();
    }
}
