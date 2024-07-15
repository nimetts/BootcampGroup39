using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
   public GameObject player;//takip edilen oyuncu
    private Vector2 startPoint;//başlangiç noktası
    
    [Header ("özelikler")]
        public float speed;
        public int health;
        public int currentHealth;
        public int attack;
        public float attackSpeed;
        public bool Isattack=false;
    
    [Header ("test")]
        public float distanceF;//max takip mesafesi
        public float distance;//aradakı mesafe
        public float nearest=2000;//en yakın
        private Follow Takip;
        

    void Start()
    {
        currentHealth = health;//başlangiç canı
        startPoint = this.transform.position;//başlangiç noktası
        //allPlayer = GameObject.FindGameObjectsWithTag("Player").ToList();
        Takip = GetComponentInChildren<Follow>();
    }

    void Update()
    {
        #region karar verme
            foreach (var item in Takip.player)
            {
                distance = Vector2.Distance(this.transform.position, item.transform.position);
                if(distance < nearest){
                    player=item;
                    nearest = distance;
                }
            }
        nearest = 2000;
        #endregion karar verme 
    }
    void FixedUpdate()
    {
        #region hareket
            //Vector2 direction = player.transform.position - transform.position;
            //direction.Normalize();
            if(!Isattack){
                if(distance <= distanceF&&Takip.player.Count!=0)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, startPoint , speed * 1.25f * Time.deltaTime);
                }
            }
        #endregion hareket
    }
    
    public void TakeDamage(int hasar){
        health -= hasar;
        if(health<=0){
            Destroy(this);
        }
    }

}
