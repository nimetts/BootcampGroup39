using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sword : MonoBehaviour
{
    private CADI player;

    void Start() {
        player = GetComponent<CADI>();
    }

    void Update() {
        if(player.CantAttack){
            
        }
    }
}
