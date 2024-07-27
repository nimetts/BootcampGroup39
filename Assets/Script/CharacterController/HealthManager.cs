using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int startingHealth; // Ba�lang��taki can�
    public int currentHealth; // �u anki can�
    public bool deneme=true;
    // �zellikler
    public float walkSpeed; // Yürüme hızı
    public float runSpeed; // Koşma hızı

    void Start()
    {
        currentHealth = startingHealth;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        gameObject.SetActive(deneme);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Karakterin �l�m i�lemleri
        gameObject.SetActive(false); // veya ba�ka bir �l�m animasyonu veya efekti oynat�labilir
    }
    
}
