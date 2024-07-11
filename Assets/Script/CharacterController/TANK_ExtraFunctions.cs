using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANK_ExtraFunctions : MonoBehaviour
{

    // �zellikler
    private bool canImmobilize = false;
    private bool canReflectDamage = false;
    private bool canBreakRocks = false;
    private bool canAbsorbDamage = false;

    private Animator animator; // Animator bile�eni

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bile�enini al
    }

    void Update()
    {
        // Ko�ma animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Yak�n d�v��te rakiplerini etkisiz hale getirme
        if (other.CompareTag("Enemy") && canImmobilize)
        {
            ImmobilizeEnemy(other.gameObject);
        }
        // Kayalar� k�rma
        else if (other.CompareTag("Rock") && canBreakRocks)
        {
            BreakRock(other.gameObject);
        }
        // Arkada��n ald��� hasar�n %25'ini absorbe etme
        else if (other.CompareTag("Friend") && canAbsorbDamage)
        {
            //AbsorbDamageFromFriend(other.gameObject);
        }
    }

    void ImmobilizeEnemy(GameObject enemy)
    {
        // D��man� etkisiz hale getirme i�lemi
        enemy.SetActive(false);
        StartCoroutine(EnableEnemyAfterDelay(enemy, 5f));
    }

    IEnumerator EnableEnemyAfterDelay(GameObject enemy, float delay)
    {
        yield return new WaitForSeconds(delay);
        enemy.SetActive(true);
    }

    void BreakRock(GameObject rock)
    {
        // Kaya k�rma i�lemi
        Destroy(rock);
    }

    }

