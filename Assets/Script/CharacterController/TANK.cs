using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TANK : MonoBehaviour
{
  

    // Özellikler
    private bool canImmobilize = false;
    private bool canBreakRocks = false;


    private bool isGrounded; // Karakterin yerde olup olmadığını kontrol eder
    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    void Start()
    {
       
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.contacts[0].normal.y > 0.5)
        {
            isGrounded = true;
            animator.SetBool("grounded", true);
        }
    }
}

