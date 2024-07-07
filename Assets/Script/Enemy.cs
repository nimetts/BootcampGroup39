using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField]private Effect _data;
    private Vector2 startPoint;
    private List<GameObject> allPlayer;


    public float speed;
    public int health;
    private int currentHealth;
    public int attack;

    public float distanceF;//max takip mesafesi
    public float distance;//aradakı mesafe
    private float nearest=2000;//en yakın

    private float curEffect= 0f;
    private float lastTick = 0f;

    void Start()
    {
        currentHealth = health;//başlangiç canı için
        startPoint = this.transform.position;
        allPlayer = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    void Update()
    {
        //animasiyon için
        #region karar verme
        foreach (var item in allPlayer)
        {
            distance = Vector2.Distance(transform.position, item.transform.position);
            if(distance< nearest){
                player=item;
            }
        }
        nearest = 200;
        #endregion karar verme
        #region hareket
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        if(distance <= distanceF)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, startPoint , speed * 1.25f * Time.deltaTime);
        }
        #endregion hareket
        
        if(_data !=null) HandleE();
    }

    void OnCollisionStay2D(Collision2D other) {
        //hasarVerme(other.gameObject);
    }
    void OnCollisionEnter2D(Collision2D other) {
        var effectable = other.gameObject.GetComponent<effectCon>();
        
        if(effectable != null){
            effectable.ApplyE(_data);
        }
    }
   
    public void TakeDamage(int hasar){
        health -= hasar;
        if(health<=0){
            Destroy(this);
        }
    }

    public void hasarVerme(GameObject player){
        var atm = player.GetComponent<CADI>();
        if(atm!= null ){
            atm.TakeDamage(attack);
            //atm.Speedslow();//yavaşlam etkisi
        }
    }

    
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
        if(curEffect >= _data.lifetTime){
            RemoveE();
        }
        
    }
}
