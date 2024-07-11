using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MADENCI_ExtraFunctions : MonoBehaviour
{

    private bool canDamageWithShovel = true; // Kazmayla hasar verebilir
    private bool canHookEnemies = true; // Düþmanlarý kancayla çekebilir
    private bool canHookWitches = false; // Cadýlarý kancayla çekemez

    // Kazma ve kancalar için referanslar
    public Transform shovelTransform;
    public Transform hookTransform;

    void Start()
    {
       
    }

    void Update()
    {
        // Kazma kullanýmý
        if (canDamageWithShovel && Input.GetButtonDown("Fire1"))
        {
            UseShovel();
        }

        // Kancayý kullanma
        if ((canHookEnemies || canHookWitches) && Input.GetButtonDown("Fire2"))
        {
            UseHook();
        }
    }

    void UseShovel()
    {
        // Kazma kullanýmý için kod
        // Örneðin:
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
        // Kancayý kullanma için kod
        // Örneðin:
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
        // Cadýyý silahsýz býrakma iþlemi
        // Örneðin:
        witch.SetActive(false);
        yield return new WaitForSeconds(5f);
        witch.SetActive(true);
    }

    void PullEnemy(GameObject enemy)
    {
        // Düþmaný kendine çekme iþlemi
        // Örneðin:
        // enemy.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(enemy.transform.position, transform.position, Time.deltaTime * pullSpeed));
    }

 
}
