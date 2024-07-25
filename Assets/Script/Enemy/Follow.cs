using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public List<GameObject> player= new List<GameObject>();
    private AIDestinationSetter targetS;

    [Header ("mesafe")]
        private float distance;//aradakı mesafe
        private float nearest=2000;//en yakın
        private Transform start;//en yakın
    
    void Start() {
        targetS = GetComponentInParent<AIDestinationSetter>();
        start = GetComponentInParent<Transform>();
        
    }
    void Update()
    {
        #region karar verme
            if(player.Count!=0){
                foreach (var item in player)
                    {
                        distance = Vector2.Distance(this.transform.position, item.transform.position);
                        if(distance < nearest){
                            targetS.target=item.transform;
                            nearest = distance;
                        }
                    }
            }
            else
            {
                targetS.target = start;
            }
            nearest = 2000;
        #endregion karar verme
    }

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
