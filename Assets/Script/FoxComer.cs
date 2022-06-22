using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FoxComer : MonoBehaviour
{
    
    
            public int score;
        public Text TXTscore;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         TXTscore.text = "Puntaje " + score;
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var tag = other.gameObject.tag;

        if (tag == "Fruta")
        {
         
            score++;
            Destroy(other.gameObject);
        }
        
     
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        var tag = other.gameObject.tag;
        if (tag == "Puerta")
        {
            SceneManager.LoadScene("Escena2");
        }
    }
    
    
    
}
