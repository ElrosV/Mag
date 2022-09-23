using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mag : MonoBehaviour
{
    public float speed, s_jump, naprav;
    public float M, M_max, vost;

    public GameObject bar, strela, mesto;

    public bool ground;
    public Transform gr;
    public float radius;
    public LayerMask sloy;

    public Vector2 scaler;
    Rigidbody2D rb;
    Animator anim;

    public Image mana;


    void Start()
    {
        M = M_max;
        scaler = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        atake();
        jump();

    }


    void FixedUpdate()
    {
        step();
        Manabar();

    }

    private void step()//движение
    {
        naprav = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(naprav * speed, rb.velocity.y);

        if (naprav > 0 && scaler.x < 0)
            napravlenie();
        else if (naprav < 0 && scaler.x > 0)
            napravlenie();

        if(naprav != 0)
            anim.SetBool("step", true);
        else
            anim.SetBool("step", false);

    }

    void napravlenie()//направление объекта
    {
        scaler.x *= -1;
        transform.localScale = scaler;
        bar.transform.localScale = scaler;
    }

    private void jump()//прыжок
    {
        ground = Physics2D.OverlapCircle(gr.position, radius, sloy);
        if (Input.GetKeyDown(KeyCode.Space) && ground)
            rb.velocity = Vector2.up * s_jump;
    }

    private void Manabar()//полоска маны
    {
        mana.fillAmount = M / M_max;
        if (M < M_max)
            M += vost;
    }


    private void atake()//анимация атаки
    {
        if (Input.GetMouseButtonDown(0) && M >= M_max)
           anim.SetBool("atake", true);
        else
           anim.SetBool("atake", false);
    }

    private void igni()//создание магии
    {
        Instantiate(strela, mesto.transform.position, Quaternion.identity);
        M -= M_max;
    }

    private void OnDrawGizmosSelected()//прорисовка радиуса
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gr.position, radius);
    }

}
