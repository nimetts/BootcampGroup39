using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CADI : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    private Rigidbody2D rb;
    private HealthManager status;
    
    private float moveDirection = 0f; // Hareket yönü
    private float moveDirectionY = 0f; // Hareket yönü

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        _animator = GetComponent<Animator>(); // Animator bileşenini al
        _transform = GetComponent<Transform>(); // Animator bileşenini al
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
        status = GetComponent<HealthManager>();
    }

    void Update()
    {
        // Yürüme veya koşma hareketi
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? status.runSpeed : status.walkSpeed;
        moveDirection = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDirectionY = Input.GetAxisRaw("Vertical") * moveSpeed;

        

        // Animasyon kontrolü
        _animator.SetFloat("speed", Mathf.Abs(moveDirection));
    }

    void FixedUpdate()
    {// Sprite flip işlemi
        if (moveDirection < 0)
        {
            _transform.Rotate(0f,0f,180f);
        }
        else if (moveDirection > 0)
        {
           _transform.Rotate(0f,0f,0f);
        }
        // Hareketi uygula
        rb.velocity = new Vector2(moveDirection,moveDirectionY);
    }
}

