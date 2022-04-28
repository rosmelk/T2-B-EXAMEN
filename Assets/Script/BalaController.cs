using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{
    public float Velocidad2=20;
    
    private Rigidbody2D _rb;
    private BoxCollider2D _bColider;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        Destroy(this.gameObject, 3);
    }
    void Update()
    {
        _rb.velocity = new Vector2(Velocidad2, _rb.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
       
    }

  
}