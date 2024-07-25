using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
   private Vector2 startPoint;//başlangiç noktası
    
    [Header ("özelikler")]
        public float speed;
        public int health;
        public int currentHealth;
        public int attack;
        public float attackSpeed;
        public bool Isattack=false;
    
    void Start()
    {
        currentHealth = health;//başlangiç canı
        startPoint = this.transform.position;//başlangiç noktası
    }

    void Update()
    {}
    void FixedUpdate()
    {
        //animasiyon
    }
    
    public void TakeDamage(int hasar){
        health -= hasar;
        if(health<=0){
            Destroy(this);
        }
    }

}
