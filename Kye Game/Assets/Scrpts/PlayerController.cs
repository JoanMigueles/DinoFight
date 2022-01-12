using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask mundoLayer;
    public AudioClip sonidoSalto;
    public float velocidad;
    public float velocidadSalto;
    public string axisPlayer;
    public KeyCode jumpPlayer;
    public Transform checkGround;
    public Transform slash;
    public Transform fire;

    private bool salto;
    private AudioSource audios;
    private SpriteRenderer jug;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector2 movimiento;
    private Vector2 movimientoSalto;

    private Vector3 posIni;
    bool iniciarMov;

    void Start()
    {
        //Obtener componentes
        audios = GetComponent<AudioSource>();
        jug = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movimientoSalto = Vector2.zero;
        salto = false;
        posIni = transform.position;
        iniciarMov = false;
    }

    void Update()
    {
        if (iniciarMov)
        {
            //Leer movimiento horizontal y animación
            float moverHorizontal = Input.GetAxis(axisPlayer);
            ComprobarAnimacion(moverHorizontal);
            movimiento = new Vector2(moverHorizontal * velocidad, rb.velocity.y);

            //Leer movimiento vertical (salto)
            if (Input.GetKeyDown(jumpPlayer))
            {
                movimientoSalto = (Vector2.up * velocidadSalto);
                salto = true;
            }
        }
        else
        {
            OnDeath();
        }
    }

    //Bucle que actualiza el movimiento
    private void FixedUpdate()
    {
        bool tocandoSuelo = Physics2D.OverlapCircle(checkGround.position, 0.2f, mundoLayer);
        if (salto && tocandoSuelo)
        {
            movimiento += movimientoSalto; 
            movimientoSalto = Vector2.zero;
            audios.PlayOneShot(sonidoSalto, 0.5f);
            salto = false;
        }
        rb.velocity = movimiento;
    }

    //Comprueba las animaciones que debe activar
    private void ComprobarAnimacion(float mov)
    {
        //Voltear personaje y patada
        if (mov < 0)
        {
            if (jug.flipX == false)
            {
                slash.RotateAround(transform.position, transform.up, -180);
                fire.RotateAround(transform.position, transform.up, -180);
            }
            jug.flipX = true;
        }
        else if (mov > 0)
        {
            if (jug.flipX == true)
            {
                slash.RotateAround(transform.position, transform.up, -180);
                fire.RotateAround(transform.position, transform.up, -180);
            }
            jug.flipX = false;
        }

        //Animacion caminar
        if (mov != 0)
        {
            anim.SetBool("caminando", true);
        }
        else
        {
            anim.SetBool("caminando", false);
        }
    }

    public void OnDeath()
    {
        transform.position = posIni;
    }

    public void IniciarJuego()
    {
        iniciarMov = true;
    }

    public void PararJuego()
    {
        iniciarMov = false;
    }
}
