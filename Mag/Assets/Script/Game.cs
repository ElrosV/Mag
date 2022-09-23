using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public GameObject[] mesto;
    public GameObject[] vrag;
    public GameObject mag;

    public int solder, isold, xsold;

    public Text txt;

    public GameObject icon;


    void Start()
    {
        Time.timeScale = 1f;
        Instantiate(mag, mesto[0].transform.position, Quaternion.identity);
        isold = 5;
        xsold = isold;
        icon.SetActive(false);
    }

    void Update()
    {
        spawn();

        txt.text = Time.time.ToString();

        finish();
    }

    private void spawn()//создание противников на уровне
    {
        if (isold > 1)
        {
            for(int i = 1; i < 6; i++)
            {
                solder = Random.Range(0, 2);
                Instantiate(vrag[solder], mesto[i].transform.position, Quaternion.identity);
                isold--;
            }
        }
    }

    private void finish()//победа над противниками
    {
        if (xsold <= 0)
        {
            icon.SetActive(true);
            Time.timeScale = 0f;
        }

    }

}
