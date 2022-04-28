using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMegaman : MonoBehaviour
{
    public float fuerzaSalto = 10;
    public float velocidad = 10;

   
    
    private Rigidbody2D _rb;
    private Animator _anima_personaje;
    private SpriteRenderer _renderer;
    
    public GameObject balaPrefab;
    public GameObject balaPrefab2;
    public GameObject balaPrefab3;
    private const string _EstadoAnimacion ="Estado";
    private const int _quieto = 0;
    private const int _correr = 1;
    private const int _saltar = 3;
    private const int _correrDisparando = 2;
    
    
    private const int derecha = 1;
    private const int izquierda = -1;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anima_personaje = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimacionPersonaje(_quieto);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
       
        
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazamiento(izquierda);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazamiento(derecha);
        }
        
        if (Input.GetKeyUp(KeyCode.X)) {
            Disparar();
        }    
      
        //disparar 
        if (Input.GetKeyDown(KeyCode.X) )
        {
            Invoke("Disparar2", 3f);
        }
        if (Input.GetKeyDown(KeyCode.X) )
        {
            Invoke("Disparar3", 5f);
        }
       
        
        //saltar
        if (Input.GetKeyUp(KeyCode.Space))//Cuando suelto la tecla
        {
            
            _rb.AddForce(Vector2.up * fuerzaSalto , ForceMode2D.Impulse);
            AnimacionPersonaje(_saltar);
        }
        
    }
    
    
    //metodo para la animacion
    private void AnimacionPersonaje(int animation)
    {
        _anima_personaje.SetInteger(_EstadoAnimacion, animation);
    }
    
    //metodo para desplazarse
    private void Desplazamiento(int position)
    {
        _rb.velocity = new Vector2(velocidad * position, _rb.velocity.y);
        _renderer.flipX = position == izquierda;
        AnimacionPersonaje(_correr);
    }
    
    private void Disparar()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        AnimacionPersonaje(_correrDisparando);
        var bulletGo =Instantiate(balaPrefab, new Vector2(x,y), quaternion.identity);

        if (_renderer.flipX)
        {
            var controller = bulletGo.GetComponent<BalaController>();
            controller.Velocidad2 = controller.Velocidad2 * -1;
        }
    }

    private void Disparar2()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        AnimacionPersonaje(_correrDisparando);
        var bulletGo1 =Instantiate(balaPrefab2, new Vector2(x,y),quaternion.identity);
        if (_renderer.flipX)
        {
            var controller = bulletGo1.GetComponent<BalaController>();
            controller.Velocidad2 = controller.Velocidad2 * -1;
        }
        
    }
    private void Disparar3()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        AnimacionPersonaje(_correrDisparando);
        var bulletGo2 =Instantiate(balaPrefab3, new Vector2(x,y),quaternion.identity);
        if (_renderer.flipX)
        {
            var controller = bulletGo2.GetComponent<BalaController>();
            controller.Velocidad2 = controller.Velocidad2 * -1;
        }
        
    }

  
}
