﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("RestartAfterTime", 2f);
    }


    void RestartAfterTime()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}//class ends



















