using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public List<GameObject> player= new List<GameObject>();

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            player.Add(other.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            player.Remove(other.gameObject);
        }
    }
}
