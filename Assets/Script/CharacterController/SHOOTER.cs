using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOOTER : MonoBehaviour
{
    public bool CantAttack = false;
    public float AttackSpeed=0.3f;
    public float AttackRenge=2;
    public int Attack;
    private Transform child;
    private Animator _anim;

    void Start() {
        child = GetComponent<Transform>();
        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _anim.SetBool("Isattack",true);
            UseKnife();
        }
    }
    public void UseKnife()
    {
        if (CantAttack)
            return;
        CantAttack = true;
        StartCoroutine(DelayAttack());
    }
    void OnTriggerEnter2D(Collider2D other) {
        EnemyStatus health;
        if((health = other.gameObject.GetComponent<EnemyStatus>())&&CantAttack)
        {
            health.TakeDamage(Attack);
        } 
    }
    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(AttackSpeed);
        CantAttack = false;
        _anim.SetBool("Isattack",false);
    }
}
