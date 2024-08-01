using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int startingHealth; // Ba�lang��taki can�
    public int currentHealth; // �u anki can�
    public bool Ishit=false;
    public bool Isdie=false;
    // �zellikler
    public float walkSpeed; // Yürüme hızı
    public float runSpeed; // Koşma hızı

    void Start()
    {
        currentHealth = startingHealth;
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Ishit=true;
        if (currentHealth <= 0)
        {
            Isdie=true;
            Die();
        }
    }

    void Die()
    {
        // Karakterin �l�m i�lemleri
        gameObject.SetActive(false); // veya ba�ka bir �l�m animasyonu veya efekti oynat�labilir
    }
    
}
