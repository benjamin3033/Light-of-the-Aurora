using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject GameHud;
    

    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameFail()
    {
        
        GameHud.SetActive(false);
        GameOver.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}

