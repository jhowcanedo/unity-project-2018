using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptEnemy : MonoBehaviour
{
    public float velocidade;
    //public float distancia;
    public int XMoveDirection;
    //public Transform groundDetection;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * velocidade;

        if (hit.distance < 0.5f)
        {
            Flip();
        }
    }

    void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
            transform.Rotate(new Vector2(0, 180));
        }
        else
        {
            XMoveDirection = 1;
            transform.Rotate(new Vector2(0, 180));
        }            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Destroy(collision.gameObject);
        }
    }

    public void Hurt()
    {
        Destroy(this.gameObject);
    }
}
