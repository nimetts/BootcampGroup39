using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CADI : MonoBehaviour
{
    public bool CantAttack = false;
    public float AttackSpeed=0.3f;
    public float Attack=2;
    private Transform child;
    private Animator _anim;

    void Start() {
        child = GetComponentInChildren<Transform>();
        _anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        // Silah kullan�m�
        if (Input.GetButtonDown("RightAnalogClick"))
        {
            Shoot();
        }

        // B��ak kullan�m�
        if (Input.GetButtonDown("LeftAnalogClick"))
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

    public void UseKnife()
    {
        if (CantAttack)
            return;
        _anim.SetBool("Isattack",true);
        CantAttack = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackSpeed);
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(child.transform.position,Attack))
        {
            //Debug.Log(collider.name);
            EnemyStatus health;
            if(health = collider.GetComponent<EnemyStatus>())
            {
                health.TakeDamage(1);
            }
        }
        CantAttack = false;
        _anim.SetBool("Isattack",false);
    }

}

