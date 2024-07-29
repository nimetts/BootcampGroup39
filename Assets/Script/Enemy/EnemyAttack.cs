using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyStatus enemy;//özeliklerin olduğu script
    private float ColTimer = Mathf.Infinity;
    private GameObject hedef;
    
    
    void Start()
    {
        enemy = GetComponent<EnemyStatus>();
    }
    void FixedUpdate() {
       ColTimer += Time.deltaTime;
       #region saldiri
            if(enemy.Isattack){
                if (ColTimer>=enemy.attackSpeed)
                {
                    DealDamage(hedef);
                    ColTimer=0;
                }
            }
            else{
                ColTimer = 0;
            }
        #endregion saldiri
    }
    private void DealDamage(GameObject player){
        var atm = player.GetComponent<HealthManager>();
        if(atm!= null){
            atm.TakeDamage(enemy.attack);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Player"){
            enemy.Isattack=true;
            hedef=other.gameObject;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        enemy.Isattack=false;
        hedef=null;
    }
}
