using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysp : MonoBehaviour
{
   public GameObject[] _gameObject;

   public float say;
   public float tekrar;

    void Update() {
        say += Time.deltaTime;
        if(say>tekrar){
            int randomIndex = Random.Range(0,_gameObject.Length);
            Vector2 randomSposition = new Vector2(Random.Range(-10,10),Random.Range(-10,10));
            Instantiate(_gameObject[randomIndex],randomSposition,Quaternion.identity);
            say=0;
        }
    }
}
