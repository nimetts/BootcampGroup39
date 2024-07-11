using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MADENCI_ExtraFunctions : MonoBehaviour
{

    private bool canDamageWithShovel = true; // Kazmayla hasar verebilir
    private bool canHookEnemies = true; // D��manlar� kancayla �ekebilir
    private bool canHookWitches = false; // Cad�lar� kancayla �ekemez

    // Kazma ve kancalar i�in referanslar
    public Transform shovelTransform;
    public Transform hookTransform;

    void Start()
    {
       
    }

    void Update()
    {
        // Kazma kullan�m�
        if (canDamageWithShovel && Input.GetButtonDown("Fire1"))
        {
            UseShovel();
        }

        // Kancay� kullanma
        if ((canHookEnemies || canHookWitches) && Input.GetButtonDown("Fire2"))
        {
            UseHook();
        }
    }

    void UseShovel()
    {
        // Kazma kullan�m� i�in kod
        // �rne�in:
        // RaycastHit2D hit = Physics2D.Raycast(shovelTransform.position, shovelTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController6 enemy = hit.collider.GetComponent<EnemyController6>();
        //     if (enemy != null)
        //     {
        //         enemy.TakeDamage(1); // Kazma ile hasar verme
        //     }
        // }
    }

    void UseHook()
    {
        // Kancay� kullanma i�in kod
        // �rne�in:
        // RaycastHit2D hit = Physics2D.Raycast(hookTransform.position, hookTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController6 enemy = hit.collider.GetComponent<EnemyController6>();
        //     if (enemy != null)
        //     {
        //         if (enemy.IsWitch && canHookWitches)
        //         {
        //             StartCoroutine(DisarmWitch(enemy.gameObject));
        //         }
        //         else if (!enemy.IsWitch && canHookEnemies)
        //         {
        //             PullEnemy(enemy.gameObject);
        //         }
        //     }
        // }
    }

    IEnumerator DisarmWitch(GameObject witch)
    {
        // Cad�y� silahs�z b�rakma i�lemi
        // �rne�in:
        witch.SetActive(false);
        yield return new WaitForSeconds(5f);
        witch.SetActive(true);
    }

    void PullEnemy(GameObject enemy)
    {
        // D��man� kendine �ekme i�lemi
        // �rne�in:
        // enemy.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(enemy.transform.position, transform.position, Time.deltaTime * pullSpeed));
    }

 
}
