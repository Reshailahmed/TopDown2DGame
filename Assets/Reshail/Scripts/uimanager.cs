using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uimanager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject YouWin;

    public void Win()
    {
        YouWin.SetActive(true);
    }

    public void Lose()
    {
        GameOver.SetActive(true);
    }
}

