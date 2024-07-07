using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANK : MonoBehaviour
{    public int startingHealth = 3; // Başlangıçtaki canı
    private int currentHealth; // Şu anki canı

    // Özellikler
    private bool canImmobilize = false;
    private bool canReflectDamage = false;
    private bool canBreakRocks = false;
    private bool canAbsorbDamage = false;

    private bool isGrounded; // Karakterin yerde olup olmadığını kontrol eder
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    void Start()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        animator = GetComponent<Animator>(); // Animator bileşenini al
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        // Karakterin hareketi
        float moveHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveHorizontal * GetSpeed(), rb.velocity.y);

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
        if ((isGrounded || Input.GetKeyDown(KeyCode.W)) && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        // Koşma animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void FixedUpdate()
    {
        // Zıplama durumu kontrolü
        if (rb.velocity.y == 0)
        {
            isGrounded = true;
            animator.SetBool("grounded", true);
        }
        else
        {
            isGrounded = false;
            animator.SetBool("grounded", false);
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector2(0f, GetJumpForce()), ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetTrigger("jump");
        animator.SetBool("grounded", false);
    }

    float GetSpeed()
    {
        // Koşma durumunu kontrol et
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            return 8f; // Koşma hızı
        }
        else
        {
            return 5f; // Normal yürüme hızı
        }
    }

    float GetJumpForce()
    {
        // Zıplama kuvveti
        return 8f;
    }

    void TakeDamage(int damageAmount)
    {
        // Hasar alma işlemi
        if (canReflectDamage)
        {
            // Hasarın %10'unu geri yansıt
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
        // Karakterin ölüm işlemleri
        gameObject.SetActive(false); // veya başka bir ölüm animasyonu veya efekti oynatılabilir
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.contacts[0].normal.y > 0.5)
        {
            isGrounded = true;
            animator.SetBool("grounded", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Yakın dövüşte rakiplerini etkisiz hale getirme
        if (other.CompareTag("Enemy") && canImmobilize)
        {
            ImmobilizeEnemy(other.gameObject);
        }
        // Kayaları kırma
        else if (other.CompareTag("Rock") && canBreakRocks)
        {
            BreakRock(other.gameObject);
        }
        // Arkadaşın aldığı hasarın %25'ini absorbe etme
        else if (other.CompareTag("Friend") && canAbsorbDamage)
        {
            AbsorbDamageFromFriend(other.gameObject);
        }
    }

    void ImmobilizeEnemy(GameObject enemy)
    {
        // Düşmanı etkisiz hale getirme işlemi
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
        // Kaya kırma işlemi
        Destroy(rock);
    }

    void AbsorbDamageFromFriend(GameObject friend)
    {
        // Arkadaşın aldığı hasarın %25'ini absorbe etme
        /*CharacterController3 friendController = friend.GetComponent<CharacterController3>();
        if (friendController != null)
        {
            int absorbedDamage = Mathf.RoundToInt(friendController.currentHealth * 0.25f);
            currentHealth += absorbedDamage;
        }*/
    }

}
