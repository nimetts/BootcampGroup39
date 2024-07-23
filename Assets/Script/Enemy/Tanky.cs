using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanky : MonoBehaviour
{
    private EnemyStatus enemy;//özeliklerin olduğu script
    private float ColTimer = Mathf.Infinity;
    private GameObject hedef;
    
    void Start()
    {
        enemy = GetComponent<EnemyStatus>();
    }

    void Update()
    {
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
        enemy.Isattack=true;
        hedef=other.gameObject;
    }
    void OnCollisionExit2D(Collision2D other) {
        enemy.Isattack=false;
        hedef=null;
    }

   /*
   #region effect
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
    #endregion effect*/
}
