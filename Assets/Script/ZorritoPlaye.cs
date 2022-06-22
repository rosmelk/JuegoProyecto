using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ZorritoPlaye : MonoBehaviour
{


    public float fuerzaSalto = 10;
    public float velocidad = 10;
    private Rigidbody2D _rb;
    private Animator _anima_personaje;
    private SpriteRenderer _renderer;

   
    
    
    private const int derecha = 1;
    private const int izquierda = -1;
    private const int arriba = 1;
    
    private const string _EstadoAnimacion ="Estado";
    private const int  caminar = 0;
    private const int  correr = 1;
    private const int  Saltar = 2;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anima_personaje = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        


    }

   
    void Update()
    {
       
        AnimacionPersonaje(caminar);
        _rb.velocity = new Vector2(0, _rb.velocity.y);
        
        //Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Desplazamiento(derecha);
        }
        //izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Desplazamiento(izquierda);
        }
        
  
        //saltar
        if (Input.GetKeyUp(KeyCode.Space))//Cuando suelto la tecla
        {
            _rb.AddForce(Vector2.up * fuerzaSalto , ForceMode2D.Impulse);
            AnimacionPersonaje(Saltar);
        }
    }
    //metodo para desplazarse
    private void Desplazamiento(int position)
    {
        _rb.velocity = new Vector2(velocidad * position, _rb.velocity.y);
        _renderer.flipX = position == izquierda;
        AnimacionPersonaje(correr);
    }
    
    private void AnimacionPersonaje(int animation)
    {
        _anima_personaje.SetInteger(_EstadoAnimacion, animation);
    }
    
    
    

}
