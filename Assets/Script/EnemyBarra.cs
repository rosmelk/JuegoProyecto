using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarra : MonoBehaviour
{
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Zorro2Player>().TomarD(20);
        }
    }
}
