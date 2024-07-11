using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 3; // Baþlangýçtaki caný
    private int currentHealth; // Þu anki caný

    // Özellikler
    public bool canReflectDamage = false;
    public bool canAbsorbDamage = false;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Hasar alma iþlemi
        if (canReflectDamage)
        {
            // Hasarýn %10'unu geri yansýt
            int reflectedDamage = Mathf.RoundToInt(damageAmount * 0.1f);
            currentHealth -= damageAmount - reflectedDamage;
        }
        else
        {
            currentHealth -= damageAmount;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Karakterin ölüm iþlemleri
        gameObject.SetActive(false); // veya baþka bir ölüm animasyonu veya efekti oynatýlabilir
    }

    public void AbsorbDamageFromFriend(GameObject friend)
    {
        // Arkadaþýn aldýðý hasarýn %25'ini absorbe etme
        /*CharacterController3 friendController = friend.GetComponent<CharacterController3>();
        if (friendController != null)
        {
            int absorbedDamage = Mathf.RoundToInt(friendController.currentHealth * 0.25f);
            currentHealth += absorbedDamage;
        }*/
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
