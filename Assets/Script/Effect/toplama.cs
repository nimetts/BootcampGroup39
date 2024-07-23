using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toplama : MonoBehaviour
{
    public Effect _data;

    void Update()
    {
       //nesne animasıyonu 
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            if ( 0!=_data.health)
            {   
                var Phealth = other.gameObject.GetComponent<HealthManager>();
                Phealth.currentHealth += _data.health;
            }
            if (0!=_data.Movements)
            {
                var Pspeed = other.gameObject.GetComponent<CharacterController>();
                Pspeed.speed += _data.Movements;
            }
            Destroy(this.gameObject);
        }   
    }
}
