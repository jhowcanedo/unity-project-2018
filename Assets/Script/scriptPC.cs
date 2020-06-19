using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    private Rigidbody2D rbd;
    public float velocidade;
    private Animator anim;
    private bool dir = true;
    private float altura, largura;
    public GameObject cam;

    public Transform pe;
    public LayerMask mascara;
    public float jump;
    public bool hasDied;
    
    // Start is called before the first frame update
    void Start()
    {
        altura = Camera.main.orthographicSize;
        largura = altura * Camera.main.aspect;
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hasDied = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Capturar teclado
        float dirX = Input.GetAxis("Horizontal");

        //Alterar velocidade
        rbd.velocity = new Vector2(dirX * velocidade, rbd.velocity.y);

        //Verificar direção e alterar sentido da animação
        if (dirX < 0 && dir || dirX > 0 && !dir)
        {
            transform.Rotate(new Vector2(0, 180));
            dir = !dir;
        }

        //Altera animação entre correr e parado
        if (dirX == 0)
        {
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("run", true);
        }

        //Pulo
        if (Physics2D.OverlapCircle(pe.position, .2f, mascara))
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rbd.AddForce(new Vector2(0, jump));
            }
        }

        //Morte
        if (transform.position.x < cam.transform.position.x - largura || transform.position.y < cam.transform.position.y - altura - 1)
        {
            hasDied = true;
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        scriptEnemy enemy = collision.collider.GetComponent<scriptEnemy>();

        if(enemy != null)
        {
            foreach(ContactPoint2D point in collision.contacts)
            {
                if (point.normal.y >= 10f)
                {
                    rbd.AddForce(new Vector2(0, 200));
                    enemy.Hurt();
                }
                else
                    Destroy(this.gameObject);
            }
        }
    }
}
