using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [SerializeField]private int startingHealth; // Ba�lang��taki can�
    public int currentHealth; // �u anki can�
    public bool Ishit=false;
    public bool Isdie=false;
    public HelthBar helthBar;
    // �zellikler
    public float walkSpeed; // Yürüme hızı
    public float runSpeed; // Koşma hızı

    void Start()
    {
        currentHealth = startingHealth;
        helthBar.SetMHealth(startingHealth);
    }
    void Awake() {
        var helthBar1 = GameObject.FindGameObjectWithTag("GameController");
        helthBar = helthBar1.GetComponent<HelthBar>();
    }
    void Update() {
        helthBar.SetHealth(currentHealth);
    }
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        helthBar.SetHealth(currentHealth);
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
        Destroy(gameObject);
        SceneManager.LoadScene("GameOver");
    }
    
}
