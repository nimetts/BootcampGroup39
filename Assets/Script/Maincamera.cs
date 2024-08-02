using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maincamera : MonoBehaviour
{
    private GameObject tr;
    void Start()
    {
        tr = GameObject.FindWithTag("Player");
    }

    void Update() {
        transform.position = new Vector3 (tr.transform.position.x , tr.transform.position.y, -10);
    }
}
