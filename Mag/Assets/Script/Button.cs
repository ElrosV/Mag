using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void onClickStart()//����������
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onClickExit()//�����
    {
        Application.Quit();
    }
}
