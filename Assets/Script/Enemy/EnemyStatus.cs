using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    private Vector3 oldPosition;
    private AIPath Path;
    
    [Header ("özelikler")]
        public float speed=4;
        public int health;
        public int currentHealth;
        public int attack;
        public float attackSpeed;

        public bool Isattack=false;
        private bool Ismove=false;
        private bool Ishurt=false;
        private Animator _anim;
    
    void Start()
    {
        currentHealth = health;//başlangiç canı
        oldPosition = transform.position;//lookto için
        _anim = GetComponent<Animator>();
        Path = GetComponent<AIPath>();
        Path.maxSpeed=speed;
    }
    

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //harket
        if(transform.position != oldPosition){
            _anim.SetBool("Ismove",true);
            #region lookto
                if (transform.position.x > oldPosition.x) // he's looking right
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                if (transform.position.x < oldPosition.x) // he's looking left
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                oldPosition = transform.position;
            #endregion
        }
        else{
            _anim.SetBool("Ismove",false);
            Ismove = false;
        }
        //saldırı
        if(Isattack){
            _anim.SetBool("Isattack",true);
        }
        else{
            _anim.SetBool("Isattack",false);
        }
        //hasar alma
        if(Ishurt){
            _anim.SetBool("Ishurt",true);
            Ishurt = false;
        }
        else{
           _anim.SetBool("Ishurt",false); 
        }
    }
    
    public void TakeDamage(int hasar){
        health -= hasar;
        if(health<=0){
            _anim.SetBool("Isdie",true);
            Destroy(this.gameObject,0.8f);
        }
        Ishurt = true;
    }

}
