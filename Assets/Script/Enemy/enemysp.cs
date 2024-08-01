using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysp : MonoBehaviour
{
   public GameObject[] _gameObject;

   private float say;
   public float tekrar;
   public bool active=false;
   public Transform point1;
   public Transform point2;
   public float Distance;
   public GameObject Player;
   
    void Start() {
        Player= GameObject.FindWithTag("Player");
    }
    void Update() {
        say += Time.deltaTime;
        if(active){
            if(say>tekrar){
                int randomIndex = Random.Range(0,_gameObject.Length);
                Vector2 randomSposition = new Vector2(Random.Range(point1.position.x,point2.position.x),Random.Range(point1.position.y,point2.position.y));
                if (Vector2.Distance(randomSposition,Player.transform.position) > Distance )
                {
                    Instantiate(_gameObject[randomIndex],randomSposition,Quaternion.identity);
                }
                say=0;
            }
        }
    }
}
