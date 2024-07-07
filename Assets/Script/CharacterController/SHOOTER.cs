using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOOTER : MonoBehaviour
{
        public float speed = 5f; // Hızı
    public int startingHealth = 2; // Başlangıçtaki canı
    public float jumpForce = 8f; // Zıplama kuvveti

    private int currentHealth; // Şu anki canı
    private bool isGrounded; // Karakterin yerde olup olmadığını kontrol eder
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private float moveDirection = 0f; // Hareket yönü
    private bool jump = false; // Zıplama durumu

    // Animasyon ve sprite bileşenleri
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    // Silah ve bıçak için referanslar
    public Transform weaponTransform;
    public Transform knifeTransform;

    void Start()
    {
        currentHealth = startingHealth;
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        _animator = GetComponent<Animator>(); // Animator bileşenini al
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        if (isGrounded && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                _animator.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                _animator.SetFloat("speed", speed);
            }
        }
        else if (isGrounded)
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }

        if (isGrounded && Input.GetKey(KeyCode.W))
        {
            jump = true;
            isGrounded = false;
            _animator.SetTrigger("jump");
            _animator.SetBool("grounded", false);
        }

        // Silah kullanımı
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Yakın dövüşte bıçak kullanımı
        if (Input.GetButtonDown("Fire2"))
        {
            UseKnife();
        }
    }

    void FixedUpdate()
    {
        // Karakterin hareketini gerçekleştir
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);

        // Zıplama hareketini gerçekleştir
        if (jump)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }

    void Shoot()
    {
        // Silah kullanımı için kod
        // Örneğin:
        // Instantiate(bulletPrefab, weaponTransform.position, weaponTransform.rotation);
    }

    void UseKnife()
    {
        // Bıçak kullanımı için kod
        // Örneğin:
        // RaycastHit2D hit = Physics2D.Raycast(knifeTransform.position, knifeTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController enemy = hit.collider.GetComponent<EnemyController>();
        //     if (enemy != null)
        //     {
        //         enemy.TakeDamage(999); // Tek vuruşta öldürmek için yüksek hasar verme
        //     }
        // }
    }

    public void TakeDamage(int damageAmount)
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
            _animator.SetBool("grounded", true);
        }
    }

}
