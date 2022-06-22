using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Zorro2Player : MonoBehaviour
{

    public AudioClip SaltoClip;
    public AudioSource _audioSource;
    public float volumen=1f;
    
    public static Vector2 v_inf_izq;
    public static Vector2 v_sup_der;
    
    public Slider vidaSlider;
    public float danio=0;
    
    public float fuerzaSalto = 10;
    public float velocidad = 10;
    private Rigidbody2D _rb;
    private Animator _anima_personaje;
    private SpriteRenderer _renderer;

   
    private bool puedeEscalar = false;
    
    private const int derecha = 1;
    private const int izquierda = -1;
    private const int arriba = 1;
    
    private const string _EstadoAnimacion ="Estado";
    private const int  caminar = 0;
    private const int  correr = 1;
    private const int  Saltar = 2;
    
    private void Start()
    {

        _rb = GetComponent<Rigidbody2D>();
        _anima_personaje = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        
        v_inf_izq = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        v_sup_der = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

   
    void Update()
    {
       
        AnimacionPersonaje(caminar);
        _rb.velocity = new Vector2(0, _rb.velocity.y);

        if (vidaSlider.value<=0)
        {
           Destroy(gameObject); 
           Destroy(vidaSlider);
        }
        
     
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
        
        if (Input.GetKey(KeyCode.UpArrow)&& puedeEscalar)
        {
            DesplazarseVertical(arriba);  
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
    
    
    private void OnTriggerStay2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Escalable")
        {
            puedeEscalar = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Escalable")
        {
            puedeEscalar = false;
        }
    }
    
    private void DesplazarseVertical(int position)
    {
        _rb.velocity = new Vector2(_rb.velocity.x, velocidad * position);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        
        if (col.gameObject.tag == "Player")

        {
           
            vidaSlider.value -= danio;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Queso")
        {
            
            vidaSlider.value += danio;
            Destroy(col.gameObject);
        }

        if (col.transform.CompareTag("Final"))
        {
            SceneManager.LoadScene(3);
        }

     
        
        
    }
}
