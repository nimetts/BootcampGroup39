using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOOTER : MonoBehaviour
{
    public float speed = 5f; // Hızı

    private Rigidbody2D rb; // Rigidbody2D bileşeni
    private Animator _animator; // Animator bileşeni
    private SpriteRenderer _spriteRenderer; // SpriteRenderer bileşeni
    private float moveDirection = 0f; // Hareket yönü

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        _animator = GetComponent<Animator>(); // Animator bileşenini al
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
    }

    void Update()
    {
        // Hareket kontrolü
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
        else
        {
            moveDirection = 0.0f;
            _animator.SetFloat("speed", 0.0f);
        }
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.velocity = new Vector2(moveDirection * speed, rb.velocity.y);
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
