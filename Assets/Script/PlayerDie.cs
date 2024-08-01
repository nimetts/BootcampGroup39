using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    private HealthManager healthManager;


    void Start()
    {
        healthManager = GetComponent<HealthManager>();
    }

    private void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if (healthManager.currentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
        
    }
}
