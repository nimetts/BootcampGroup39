using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int startingHealth = 3; // Ba�lang��taki can�
    [SerializeField]private int currentHealth; // �u anki can�

    // �zellikler
    public bool canReflectDamage = false;
    public bool canAbsorbDamage = false;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Hasar alma i�lemi
        if (canReflectDamage)
        {
            // Hasar�n %10'unu geri yans�t
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
        // Karakterin �l�m i�lemleri
        gameObject.SetActive(false); // veya ba�ka bir �l�m animasyonu veya efekti oynat�labilir
    }

    public void AbsorbDamageFromFriend(GameObject friend)
    {
        // Arkada��n ald��� hasar�n %25'ini absorbe etme
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
