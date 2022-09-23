using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Igni : MonoBehaviour
{
    public float speed, naprav, uron, radius;
    public LayerMask sloy;

    Rigidbody2D rb;
    public Vector2 scaler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scaler = GameObject.FindWithTag("Mag").GetComponent<Mag>().scaler;
        transform.localScale = scaler;

    }


    void FixedUpdate()
    {
        step();
        atake();
    }

    private void step()//��������
    {
        napravlenie();
        rb.velocity = new Vector2(naprav * speed, rb.velocity.y);
    }

    void napravlenie()//����������� �������
    {

        if (scaler.x == 1)
            naprav = 1;
        else
            naprav = -1;
    }

    private void atake()//��������� �����
    {
        Collider2D[] Vrag = Physics2D.OverlapCircleAll(transform.position, radius, sloy);
        Vrag[0].GetComponent<Vrag>().Damage(uron);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)//������������ 
    {
        if (collision.gameObject.tag == "ground")
            Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()//���������� ������� �����
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
