using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MADENCI : MonoBehaviour
{
    public int startingHealth = 2; // Başlangıçtaki canı
    private int currentHealth; // Şu anki canı

    // Özellikler
    private bool canDamageWithShovel = true; // Kazmayla hasar verebilir
    private bool canHookEnemies = true; // Düşmanları kancayla çekebilir
    private bool canHookWitches = false; // Cadıları kancayla çekemez

    private bool isGrounded; // Karakterin yerde olup olmadığını kontrol eder
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    private bool isRunning = false; // Koşma durumu
    public float walkSpeed = 5f; // Yürüme hızı
    public float runSpeed = 8f; // Koşma hızı
    public float jumpForce = 8f; // Zıplama kuvveti

    // Kazma ve kancalar için referanslar
    public Transform shovelTransform;
    public Transform hookTransform;

    void Start()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        // Koşma kontrolü
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        // Karakterin hareketi
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveSpeed = isRunning ? runSpeed : walkSpeed; // Koşma durumuna göre hareket hızı
        rb.velocity = new Vector2(moveHorizontal * moveSpeed, rb.velocity.y); // Yatay hareket

        // Karakterin sprite'ını gittiği yöne göre flip işlemi
        if (moveHorizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveHorizontal > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Zıplama hareketi
        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Zıplama kuvveti
            isGrounded = false;
        }

        // Kazma kullanımı
        if (canDamageWithShovel && Input.GetButtonDown("Fire1"))
        {
            UseShovel();
        }

        // Kancayı kullanma
        if ((canHookEnemies || canHookWitches) && Input.GetButtonDown("Fire2"))
        {
            UseHook();
        }

        // Koşma animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void UseShovel()
    {
        // Kazma kullanımı için kod
        // Örneğin:
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
        // Kancayı kullanma için kod
        // Örneğin:
        // RaycastHit2D hit = Physics2D.Raycast(hookTransform.position, hookTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController6 enemy = hit.collider.GetComponent<EnemyController6>();
        //     if (enemy != null)
        //     {
        //         if (enemy.IsWitch && canHookWitches)
        //         {
        //             StartCoroutine(DisarmWitch(enemy));
        //         }
        //         else if (!enemy.IsWitch && canHookEnemies)
        //         {
        //             PullEnemy(enemy);
        //         }
        //     }
        // }
    }

    IEnumerator DisarmWitch(GameObject witch)
    {
        // Cadıyı silahsız bırakma işlemi
        yield return new WaitForSeconds(5f);
        // Örneğin:
        // witch.SetActive(false);
        // veya cadıyı silahsız bırakma animasyonu veya efekti oynatılabilir
    }

    void PullEnemy(GameObject enemy)
    {
        // Düşmanı kendine çekme işlemi
        // Örneğin:
        // enemy.GetComponent<Rigidbody2D>().MovePosition(Vector2.MoveTowards(enemy.transform.position, transform.position, Time.deltaTime * pullSpeed));
    }

    void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Karakterin ölüm işlemleri
        gameObject.SetActive(false); // veya başka bir ölüm animasyonu veya efekti oynatılabilir
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.contacts[0].normal.y > 0.5)
        {
            isGrounded = true;
        }
    }

}
