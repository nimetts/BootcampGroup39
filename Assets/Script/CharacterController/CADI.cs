using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CADI : MonoBehaviour
{
    public float walkSpeed = 5f; // Yürüme hızı
    public float runSpeed = 10f; // Koşma hızı

    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private float moveDirection = 0f; // Hareket yönü

    // Animasyon ve sprite bileşenleri
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        _animator = GetComponent<Animator>(); // Animator bileşenini al
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        // Yürüme veya koşma hareketi
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        moveDirection = Input.GetAxisRaw("Horizontal") * moveSpeed;

        // Sprite flip işlemi
        if (moveDirection < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (moveDirection > 0)
        {
            _spriteRenderer.flipX = false;
        }

        // Animasyon kontrolü
        _animator.SetFloat("speed", Mathf.Abs(moveDirection));
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.velocity = new Vector2(moveDirection, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Yere temas kontrolü
        if (collision.contacts[0].normal.y > 0.5)
        {
            _animator.SetBool("grounded", true);
        }
    }
}

