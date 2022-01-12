using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public AudioClip sonidoKick;
    public GameObject slash;
    public float cooldown;
    public GameObject bala;
    public KeyCode hitButton;

    private AudioSource audios;
    private Animator anim;
    private bool patadaDisponible;
    private int balas;
    private SpriteRenderer jug;


    void Start()
    {
        audios = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        jug = GetComponent<SpriteRenderer>();
        patadaDisponible = true;
        balas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(hitButton) && patadaDisponible)
        {
            if (balas > 0)
            {
                CreateBullet();
            }
            else
            {
                anim.SetTrigger("atacar");
                audios.PlayOneShot(sonidoKick, 0.5f);
                slash.SetActive(true);
                Invoke("DeactivatePatada", 0.1f);
                patadaDisponible = false;
                Invoke("ActivarPatada", cooldown);
            }
        }
    }

    private void DeactivatePatada()
    {
        slash.SetActive(false);
    }

    private void ActivarPatada()
    {
        patadaDisponible = true;
    }

    public void ActivarBalas(int numB)
    {
        balas = numB;
    }

    private void CreateBullet()
    {
        GameObject b = Instantiate(bala, transform);
        if (!jug.flipX)
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 2);
        else
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 2);
        Destroy(b, 6f);
        balas--;
    }
}
