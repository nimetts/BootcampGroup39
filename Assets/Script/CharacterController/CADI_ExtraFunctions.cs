using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CADI_ExtraFunctions : MonoBehaviour
{
    public Transform weaponTransform;
    public Transform knifeTransform;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>(); // Animator bile�enini al
    }

    void Update()
    {
        // Silah kullan�m�
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // B��ak kullan�m�
        if (Input.GetButtonDown("Fire2"))
        {
            UseKnife();
        }
    }

    void Shoot()
    {
        // Silah kullan�m� i�in kod
        // �rne�in:
        // Instantiate(bulletPrefab, weaponTransform.position, weaponTransform.rotation);
    }

    void UseKnife()
    {
        // B��ak kullan�m� i�in kod
        // �rne�in:
        // RaycastHit2D hit = Physics2D.Raycast(knifeTransform.position, knifeTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController enemy = hit.collider.GetComponent<EnemyController>();
        //     if (enemy != null)
        //     {
        //         enemy.TakeDamage(999); // Tek vuru�ta �ld�rmek i�in y�ksek hasar verme
        //     }
        // }
    }

   
}
