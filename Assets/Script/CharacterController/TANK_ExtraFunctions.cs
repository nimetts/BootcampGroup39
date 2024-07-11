using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANK_ExtraFunctions : MonoBehaviour
{

    // Özellikler
    private bool canImmobilize = false;
    private bool canReflectDamage = false;
    private bool canBreakRocks = false;
    private bool canAbsorbDamage = false;

    private Animator animator; // Animator bileþeni

    void Start()
    {
        animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        // Koþma animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Yakýn dövüþte rakiplerini etkisiz hale getirme
        if (other.CompareTag("Enemy") && canImmobilize)
        {
            ImmobilizeEnemy(other.gameObject);
        }
        // Kayalarý kýrma
        else if (other.CompareTag("Rock") && canBreakRocks)
        {
            BreakRock(other.gameObject);
        }
        // Arkadaþýn aldýðý hasarýn %25'ini absorbe etme
        else if (other.CompareTag("Friend") && canAbsorbDamage)
        {
            //AbsorbDamageFromFriend(other.gameObject);
        }
    }

    void ImmobilizeEnemy(GameObject enemy)
    {
        // Düþmaný etkisiz hale getirme iþlemi
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
        // Kaya kýrma iþlemi
        Destroy(rock);
    }

    }

