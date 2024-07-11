using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MADENCI : MonoBehaviour
{
    public float walkSpeed = 5f; // Yürüme hızı
    public float runSpeed = 8f; // Koşma hızı

    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator animator; // Animator bileşeni
    private SpriteRenderer spriteRenderer; // SpriteRenderer bileşeni

    private bool isRunning = false; // Koşma durumu

    void Start()
    {
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

        // Koşma animasyonunu kontrol et
        animator.SetFloat("speed", Mathf.Abs(moveHorizontal));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.contacts[0].normal.y > 0.5)
        {
            animator.SetBool("grounded", true);
        }
    }
}
