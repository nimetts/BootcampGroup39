using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOOTER_ExtraFunctions : MonoBehaviour
{
   
    // Animasyon ve sprite bileþenleri
    private Animator _animator;

    // Silah ve býçak için referanslar
    public Transform weaponTransform;
    public Transform knifeTransform;

    void Start()
    {
        _animator = GetComponent<Animator>(); // Animator bileþenini al
    }

    void Update()
    {
        // Silah kullanýmý
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        // Yakýn dövüþte býçak kullanýmý
        if (Input.GetButtonDown("Fire2"))
        {
            UseKnife();
        }
    }

    void Shoot()
    {
        // Silah kullanýmý için kod
        // Örneðin:
        // Instantiate(bulletPrefab, weaponTransform.position, weaponTransform.rotation);
    }

    void UseKnife()
    {
        // Býçak kullanýmý için kod
        // Örneðin:
        // RaycastHit2D hit = Physics2D.Raycast(knifeTransform.position, knifeTransform.right);
        // if (hit.collider != null)
        // {
        //     EnemyController enemy = hit.collider.GetComponent<EnemyController>();
        //     if (enemy != null)
        //     {
        //         enemy.TakeDamage(999); // Tek vuruþta öldürmek için yüksek hasar verme
        //     }
        // }
    }

 
}
