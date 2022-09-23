using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vrag : MonoBehaviour
{
    public float HP, HPmax;
    public Image bar;


    void Start()
    {
        HP = HPmax;
    }

    void FixedUpdate()
    {
        HPbar();
    }

    private void HPbar()//полоска здоровья
    {
        bar.fillAmount = HP / HPmax;
        if (HP <= 0)
        {
            FindObjectOfType<Game>().xsold -= 1;
            Destroy(gameObject);
        }
    }

    public void Damage(float uron)//получение урона
    {
        HP -= uron;
    }


}
