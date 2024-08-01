using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _transform;
    private Rigidbody2D rb;
    private HealthManager status;
    private Vector3 oldPosition;
    
    private float moveDirection = 0f; // Hareket yönü
    private float moveDirectionY = 0f; // Hareket yönü

    void Start()
    {
        _animator = GetComponent<Animator>(); // Animator bileşenini al
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D bileşenini al
        _spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer bileşenini al
        status = GetComponent<HealthManager>();
    }

    void Update()
    {
        // Yürüme veya koşma hareketi
        float moveSpeed = Input.GetKey(KeyCode.LeftShift) ? status.runSpeed : status.walkSpeed;
        moveDirection = Input.GetAxisRaw("Horizontal") * moveSpeed;
        moveDirectionY = Input.GetAxisRaw("Vertical") * moveSpeed;
    }

    void FixedUpdate()
    {
        // Hareketi uygula
        rb.velocity = new Vector2(moveDirection,moveDirectionY);
        #region lookto
                if (transform.position.x < oldPosition.x) // he's looking right
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (transform.position.x > oldPosition.x) // he's looking left
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                oldPosition = transform.position;
            #endregion
        if(moveDirection!=0||moveDirectionY!=0){
            if(Input.GetKey(KeyCode.LeftShift)){
                _animator.SetInteger("Ismove",2);
            }
            else{
                _animator.SetInteger("Ismove",1);
            }
        }
        else
        {
            _animator.SetInteger("Ismove",0);
        }
        if(status.Ishit){
            _animator.SetBool("Ishit",true);
            status.Ishit= false;
        }
        else{
             _animator.SetBool("Ishit",false);
        }
        if(status.Isdie){
            _animator.SetBool("Isdie",true);
        }
    }
}
