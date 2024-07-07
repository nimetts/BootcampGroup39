using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour 
{
    public float speed = 2f; // Hızı
    public int startingHealth = 2; // Başlangıçtaki canı

    public int currentHealth; // Şu anki canı

    // Silah ve bıçak için referanslar
    public Transform weaponTransform;
    public Transform knifeTransform;

    private Effect _data;
    private float curEffect= 0f;
    private float lastTick = 0f;
    void Start()
    {
        currentHealth = startingHealth;
    }

    void Update()
    {
        // Karakterin hareketi
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

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

    
    public void ApplyE(Effect _data)
    {
        this._data=_data;
        
    }
    public void RemoveE()
    {
        _data=null;
    }
    public void HandleE()
    {
        curEffect += Time.deltaTime;
        if(curEffect>= _data.lifetTime){
            RemoveE();
        }
        if(_data.Movements !=0 && curEffect > lastTick ){
            lastTick += _data.TickSpeed;
            currentHealth -= _data.Amount;
        }
    }

}
